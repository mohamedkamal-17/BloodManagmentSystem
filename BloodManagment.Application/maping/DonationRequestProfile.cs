using AutoMapper;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetAllDonationRequestsBystatu;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestById;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequstsByUserId;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GetPendingDonationRequestByDonor;
using BloodManagment.Application.features.DonationRequestfeat.Queries.GettAllDonationRequests;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.maping
{
    internal class DonationRequestProfile : Profile
    {
        public DonationRequestProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<DonationRequest, GetAllDonationRequestDto>();

            CreateMap<DonationRequest, GetDonationRequestByIdDto>();

            CreateMap<DonationRequest, GetDonationRequestsByStatuDto>();


            CreateMap<DonationRequest, GetDonationRequstsByUserIdDto>();



            CreateMap<DonationRequest, PendingDonationRequestByDonorDto>();

        }
    }
}
