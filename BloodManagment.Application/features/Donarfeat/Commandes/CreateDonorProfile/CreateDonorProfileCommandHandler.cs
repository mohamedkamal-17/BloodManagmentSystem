using BloodManagment.Application.Commane;
using BloodManagment.Application.features.Donarfeat.Commandes.CreateDonor;
using BloodManagment.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BloodManagment.Application.features.Donarfeat.Commandes.CreateDonorProfile
{
    public class CreateDonorProfileCommandHandler : IRequestHandler<CreateDonorProfileCommand, int>
    {

        private readonly IUnitOfWork unitOfWorke;
        private readonly ICurrentUserService _currentUser;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateDonorProfileCommandHandler(
            IUnitOfWork unitOfWorke,
            ICurrentUserService currentUser,
            UserManager<ApplicationUser> userManager)
        {
            this.unitOfWorke = unitOfWorke;
            _currentUser = currentUser;
            _userManager = userManager;
        }

        public async Task<int> Handle(
            CreateDonorProfileCommand request,
            CancellationToken cancellationToken)
        {
            // 1️⃣ Ensure user is Donor
            var user = await _userManager.FindByIdAsync(_currentUser.UserId);

            if (user?.UserType != UserType.Donor)
                throw new ApplicationException("Only donors can create donor profiles");

            // 2️⃣ Ensure donor profile does not exist
            var existingDonor = await unitOfWorke.DonarRepository.GetByUserIdAsync(_currentUser.UserId);

            if (existingDonor != null)
                throw new ApplicationException("Donor profile already exists");

            // 3️⃣ Create donor
            var donor = new Donar
            {
                FullName = request.FullName,
                BloodGroup = request.BloodGroup,
                Gender = request.Gender,
                DonarCode = $"DN-{Guid.NewGuid().ToString()[..6]}",
                UserId = _currentUser.UserId,
                DonationCount = 0,
                IsEilgibleToDonate = IsEligibleToDonate(request.LastDonationDate, request.Gender)

            };

            await unitOfWorke.DonarRepository.AddAsync(donor);
            await unitOfWorke.SaveChangesAsync();

            return donor.Id;
        }

        private int GetDonationIntervalDays(Gender gender)
        {
            return gender switch
            {
                Gender.Male => 90,
                Gender.Female => 120,
                _ => 90
            };
        }
        private bool IsEligibleToDonate(
                         DateTime? lastDonationDate,
                         Gender gender)
        {
            if (lastDonationDate == null)
                return true;

            int requiredDays = GetDonationIntervalDays(gender);

            return (DateTime.UtcNow - lastDonationDate.Value).TotalDays >= requiredDays;
        }


    }
}
