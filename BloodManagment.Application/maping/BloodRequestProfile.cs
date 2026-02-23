using AutoMapper;
using BloodManagment.Application.features.BloodRequestfeat.Commandes.CreatBloodRequest;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetAllBloodRequests;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetByBloodGroup;
using BloodManagment.Application.features.BloodRequestfeat.Queries.GetByUserId;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.maping
{
    internal class BloodRequestProfile : Profile
    {
        public BloodRequestProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<BloodRequest, GetByBloodGroupDTO>();
            CreateMap<BloodRequest, GetByUserIdDTO>();
            CreateMap<BloodRequest, GetAllBloodRequestsDto>();
            CreateMap<CreatBloodRequestCommand, BloodRequest>();

        }
    }
}
