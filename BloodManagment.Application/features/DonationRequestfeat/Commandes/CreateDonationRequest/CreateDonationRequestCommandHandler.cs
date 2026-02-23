using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.DonationRequestfeat.Commandes.CreateDonationRequest
{
    public class CreateDonationRequestCommandHandler
    : IRequestHandler<CreateDonationRequestCommand, int>
    {
        private readonly IUnitOfWork unitOfWorke;

        private readonly ICurrentUserService _currentUser;

        public CreateDonationRequestCommandHandler(IUnitOfWork unitOfWorke,

            ICurrentUserService currentUser)
        {
            this.unitOfWorke = unitOfWorke;

            _currentUser = currentUser;
        }

        public async Task<int> Handle(
            CreateDonationRequestCommand request,
            CancellationToken cancellationToken)
        {
            // 1️⃣ Get donor by logged-in user
            var donor = await unitOfWorke.DonarRepository.GetByUserIdAsync(_currentUser.UserId);

            if (donor == null)
                throw new ApplicationException("Donor profile not found");

            // 2️⃣ Eligibility checks
            if (!donor.IsEilgibleToDonate)
                throw new ApplicationException("Donor is not eligible");

            if (donor.NextDonationDate.HasValue &&
                donor.NextDonationDate.Value > DateTime.UtcNow)
                throw new ApplicationException("Donation not allowed yet");

            // 3️⃣ Prevent duplicate pending request
            var existingRequest = await unitOfWorke.DonationRequestRepository.GetPendingDonationRequestByDonor(donor.Id);


            if (existingRequest != null)
                throw new ApplicationException("Pending donation request already exists");

            // 4️⃣ Health condition validation
            if (request.HealthCondition.HasAIDS ||
                request.HealthCondition.HasCancer ||
                request.HealthCondition.HasHeartDisease)
                throw new ApplicationException("Health condition not suitable for donation");

            // 5️⃣ Create HealthCondition
            var healthCondition = new HealthCondition
            {
                HasAnemia = request.HealthCondition.HasAnemia,
                HasJaundice = request.HealthCondition.HasJaundice,
                HasHeartDisease = request.HealthCondition.HasHeartDisease,
                HasCancer = request.HealthCondition.HasCancer,
                HasDiabetes = request.HealthCondition.HasDiabetes,
                HasAIDS = request.HealthCondition.HasAIDS,
                HasCold = request.HealthCondition.HasCold,
                IsPregnant = request.HealthCondition.IsPregnant,
                HasSkinDisease = request.HealthCondition.HasSkinDisease,
                HasBloodPressureIssue = request.HealthCondition.HasBloodPressureIssue,
                HasRecentSurgery = request.HealthCondition.HasRecentSurgery
            };

            await unitOfWorke.HealthConditionRepository.AddAsync(healthCondition);

            // 6️⃣ Create DonationRequest
            var donationRequest = new DonationRequest
            {
                RequestCode = $"DR-{Guid.NewGuid().ToString()[..8]}",
                RequestDate = DateTime.UtcNow,
                PreferredDonationDate = request.PreferredDonationDate,
                DonarId = donor.Id,
                HealthCondition = healthCondition,
                Statu = RequestStatus.Pending
            };

            await unitOfWorke.DonationRequestRepository.AddAsync(donationRequest);
            await unitOfWorke.SaveChangesAsync();

            return donationRequest.Id;
        }
    }

}
