using BloodManagment.Application.Commane;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.Hospital.Queries.GetAllHospitals
{
    public class GetAllHospitalsQueryHandler : IRequestHandler<GetAllHospitalsQuery, IList<HospitalDto>>
    {
        public GetAllHospitalsQueryHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public async Task<IList<HospitalDto>> Handle(GetAllHospitalsQuery request, CancellationToken cancellationToken)
        {
            var hospitals = await UnitOfWork.HospitalRepository.GetAllAsync();

            var result = hospitals.Select(h => new HospitalDto
            {
                Id = h.Id,
                HospitalName = h.Name,
                Address = h.Address,
                ContactNumber = h.ContactNumber
            }).ToList();

            return result;
        }
    }
}
