using AutoMapper;
using BloodManagment.Application.features.Hospital;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.maping
{
    internal class HospitalProfile : Profile
    {
        HospitalProfile()
        {

            CreateMap<Hospital, HospitalDto>().ReverseMap();
        }



    }
}
