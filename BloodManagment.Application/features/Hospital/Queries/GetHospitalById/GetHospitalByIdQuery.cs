using BloodManagment.Application.features.Hospital;
using MediatR;

namespace BloodManagment.Application.features.Hospitalfeat.Queries.GetHospitalById
{
    public class GetHospitalByIdQuery : IRequest<HospitalDto>
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
    }
}
