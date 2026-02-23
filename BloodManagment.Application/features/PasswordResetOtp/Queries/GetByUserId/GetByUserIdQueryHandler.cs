using BloodManagment.Application.Commane;
using MediatR;

namespace BloodManagment.Application.features.PasswordResetOtp.Queries.GetByUserId
{
    public class GetByUserIdQueryHandler : IRequestHandler<GetByUserIdQuery, PasswordResetOtpDto>
    {
        private readonly IUnitOfWork unitOfWorke;

        public GetByUserIdQueryHandler(IUnitOfWork unitOfWorke)
        {
            this.unitOfWorke = unitOfWorke;
        }
        public async Task<PasswordResetOtpDto> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWorke.PasswordResetOtpRepository.GetByUserIdAsync(request.UserId);
            return new PasswordResetOtpDto
            {
                ExpireAt = entity.ExpireAt,
                IsUsed = entity.IsUsed,
                OtpHash = entity.OtpHash,


            };
        }
    }
}
