using AutoMapper;
using BloodManagment.Application.features.Hospital;
using BloodManagment.domain.Entities;

namespace BloodManagment.Application.maping
{
    public class HospitalProfile : Profile
    {
        public HospitalProfile()
        {

            CreateMap<Hospital, HospitalDto>();
            CreateMap<HospitalDto, Hospital>();
        }



    }
}
