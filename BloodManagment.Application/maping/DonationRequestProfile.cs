using AutoMapper;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetAllDonationRequestsBystatu;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestById;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GettAllDonationRequests;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.maping
{
    internal class DonationRequestProfile : Profile
    {
        public DonationRequestProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<DonationRequest, GetAllDonationRequestDto>()
            .ForMember(
                dest => dest.DonarName,
                opt => opt.MapFrom(src => src.Donar.FullName)
            );
            CreateMap<DonationRequest, GetDonationRequestByIdDto>()
               .ForMember(
                   dest => dest.DonarName,
                   opt => opt.MapFrom(src => src.Donar.FullName)
               );
            CreateMap<DonationRequest, GetAllDonationRequestsBystatuDto>()
                .ForMember(
                dest => dest.DonarName,
                opt => opt.MapFrom(src => src.Donar.FullName)
                );

        }
    }
}
