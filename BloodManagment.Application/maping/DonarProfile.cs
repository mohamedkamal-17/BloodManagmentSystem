using AutoMapper;
using BloodManagment.Application.features.Donarfeat.Queries.GetByUserId;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.maping
{
    public class DonarProfile : Profile
    {
        public DonarProfile()
        {
            CreateMap<Donar, DonarDto>().ReverseMap();
        }
    }
}
