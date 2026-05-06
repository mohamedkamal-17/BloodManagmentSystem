using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.Rescipientfeat.Commandes.CreateRescipientProfile
{
    public class CreateRescipientProfileHandler
     : IRequestHandler<CreateRescipientProfileCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public CreateRescipientProfileHandler(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public async Task<int> Handle(
            CreateRescipientProfileCommand request,
            CancellationToken cancellationToken)
        {
            // 🎯 Generate Code (simple version)
            var code = $"REC-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";

            var user =  userManager.FindByIdAsync(request.UserId).Result;
            


            var rescipient = new Rescipient
            {
                FullName = user.FullName,
                Gender = request.Gender,
                UserId = request.UserId,
                RescipientCode = code
            };

            await _unitOfWork.RecipientRepository.AddAsync(rescipient);
            await _unitOfWork.SaveChangesAsync();

            return rescipient.Id;
        }
    }
}
