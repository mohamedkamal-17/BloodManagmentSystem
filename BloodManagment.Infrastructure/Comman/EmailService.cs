using BloodManagment.Application.Commane;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace BloodManagment.Infrastructure.Comman
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendAsync(string to, string subject, string body, bool isHtml = true)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(_settings.DisplayName, _settings.Email));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = subject;

            message.Body = isHtml
                ? new TextPart("html") { Text = body }
                : new TextPart("plain") { Text = body };

            using var client = new SmtpClient();

            try
            {
                await client.ConnectAsync(
                    _settings.Host,
                    _settings.Port,
                    SecureSocketOptions.StartTls // 🔥 ده حل المشكلة بتاعتك
                );

                await client.AuthenticateAsync(_settings.Email, _settings.Password);

                await client.SendAsync(message);
            }
            catch (Exception ex)
            {
                // log هنا لو عندك logger
                throw new ApplicationException("Email sending failed", ex);
            }
            finally
            {
                if (client.IsConnected)
                    await client.DisconnectAsync(true);
            }
        }
    }
}
