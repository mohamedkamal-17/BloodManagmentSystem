using AutoMapper;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAllAnemiaBloodRequests;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByStatu;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestByUserId;
using BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestsByBloodGroup;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.maping
{
    public class AnemiaBloodRequestProfile : Profile
    {
        public AnemiaBloodRequestProfile()
        {
            CreateMap<AnemiaBloodRequest, GetAllAnemiaBloodRequestDto>();
            CreateMap<AnemiaBloodRequest, GetAnemiaBloodRequestByStatuDto>();
            CreateMap<AnemiaBloodRequest, GetAnemiaBloodRequestByBloodGroupDto>();
            CreateMap<AnemiaBloodRequest, GetAnemiaBloodRequestByUserIdDto>();
        }
    }
}
