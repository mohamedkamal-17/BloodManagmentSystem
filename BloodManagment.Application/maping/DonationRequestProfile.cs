using AutoMapper;
using BloodManagment.Application.features.DonationRequestfeat.Queries;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestById;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.maping
{
    internal class DonationRequestProfile : Profile
    {
        public DonationRequestProfile()
        {
            // CreateMap<Source, Destination>();

            CreateMap<DonationRequest, DonationRequestDto>().ForMember(dest => dest.DonarName,
                          opt => opt.MapFrom(src => src.Donar.FullName)); ;
            CreateMap<DonationRequest, DonationRequestDetailsDto>()
                .ForMember(dest => dest.DonarName,
                         opt => opt.MapFrom(src => src.Donar.FullName)); ;




        }
    }
}
