using AutoMapper;
using BloodManagment.Application.features.BloodUnitfeat.Queries;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.maping
{

    public class BloodUnitProfile : Profile
    {
        public BloodUnitProfile()
        {
            CreateMap<BloodUnit, BloodUnitDTO>().ReverseMap();


        }
    }
}
