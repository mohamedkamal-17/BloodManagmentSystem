using BloodManagment.Application.Specefication;


namespace BloodManagment.Application.features.PasswordResetOtp.Queries.GetByUserId
{
    public class GetByUserIdSpec : Specefication<BloodManagment.domain.Entities.PasswordResetOtp>

    {
        public GetByUserIdSpec(string userId) : base(x => x.UserId == userId
                         && !x.IsUsed
                         && x.ExpireAt > DateTime.UtcNow)

        {
        }
    }
}
