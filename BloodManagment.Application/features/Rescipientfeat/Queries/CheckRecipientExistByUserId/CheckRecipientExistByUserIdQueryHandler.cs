using BloodManagment.Application.Commane;
using BloodManagment.domain.Contracts.Repositorise;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.Rescipientfeat.Queries.CheckRecipientExistByUserId
{
    public class CheckRecipientExistByUserIdQueryHandler : IRequestHandler<CheckRecipientExistByUserIdQuery, bool>
    {
      
        private readonly IUnitOfWork unitOfWork;

        public CheckRecipientExistByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
           
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckRecipientExistByUserIdQuery request, CancellationToken cancellationToken)
        {
            // Call the repository method to check if recipient exists by UserId
            var recipient = await unitOfWork.RecipientRepository.GetByUserIdAsync(request.UserId);

            // If recipient exists, return true; otherwise false
            return recipient != null;
        }
    }
}
