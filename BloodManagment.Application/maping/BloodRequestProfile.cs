using AutoMapper;
using BloodManagment.Application.features.BloodRequestfeat.Commandes.CreatBloodRequest;
using BloodManagment.Application.features.BloodRequestfeat.Queries;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.maping
{
    internal class BloodRequestProfile : Profile
    {
        public BloodRequestProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<BloodRequest, BloodRequestDto>()
               .ForMember(dest => dest.HospitalName,
                          opt => opt.MapFrom(src => src.Hospital.Name)
                          ).ForMember(dest => dest.PatientName,
                          opt => opt.MapFrom(src => src.Rescipient.FullName));
            CreateMap<CreatBloodRequestCommand, BloodRequest>();

        }
    }
}
