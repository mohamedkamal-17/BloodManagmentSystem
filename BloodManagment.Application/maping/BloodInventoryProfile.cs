using AutoMapper;
using BloodManagment.Application.features.BloodInventoryfeat.Queries;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.maping
{
    public class BloodInventoryProfile : Profile
    {
        public BloodInventoryProfile()
        {
            CreateMap<BloodInventory, BloodInentoriesDto>();
        }
    }
}
