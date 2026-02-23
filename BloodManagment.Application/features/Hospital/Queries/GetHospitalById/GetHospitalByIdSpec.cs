using BloodManagment.Application.Specefication;

namespace BloodManagment.Application.features.Hospitalfeat.Queries.GetHospitalById
{
    public class GetHospitalByIdSpec : Specefication<domain.Entities.Hospital>
    {
        public GetHospitalByIdSpec(int id) : base(h => h.Id == id)
        {

        }
    }
}
