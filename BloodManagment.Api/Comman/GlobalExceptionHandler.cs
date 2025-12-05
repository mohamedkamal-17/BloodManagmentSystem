using BloodManagment.Application.Commane;
using BloodManagment.domain.Common;
using BloodManagment.Infrastructure.Comman;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using System.Net;
namespace BloodManagment.Api.Comman
{

    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var problem = CreateProblemDetails(exception, httpContext);

            httpContext.Response.StatusCode = problem.Status ?? 500;
            httpContext.Response.ContentType = "application/problem+json";

            await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

            return true;
        }

        private ProblemDetails CreateProblemDetails(Exception ex, HttpContext context)
        {
            return ex switch
            {
                ValidationException validationEx => new ProblemDetails
                {
                    Title = "Validation Error",
                    Status = (int)HttpStatusCode.BadRequest,
                    Detail = "One or more validation errors occurred.",
                    Extensions = { ["errors"] = validationEx.Errors }
                },

                DomainException domainEx => new ProblemDetails
                {
                    Title = "Domain Error",
                    Status = (int)HttpStatusCode.BadRequest,
                    Detail = domainEx.Message
                },

                DatabaseException dbEx => new ProblemDetails
                {
                    Title = "Database Error",
                    Status = (int)HttpStatusCode.InternalServerError,
                    Detail = dbEx.Message
                },

                NotFoundCustemException notFoundEx => new ProblemDetails
                {
                    Title = "Not Found",
                    Status = (int)HttpStatusCode.NotFound,
                    Detail = notFoundEx.Message
                },

                _ => new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Status = (int)HttpStatusCode.InternalServerError,
                    Detail = ex.Message
                }
            };
        }
    }

}
