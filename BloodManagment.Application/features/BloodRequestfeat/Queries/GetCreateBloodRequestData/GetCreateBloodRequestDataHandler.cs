using BloodManagment.Application.Commane;
using BloodManagment.domain.Contracts.Repositorise;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetCreateBloodRequestData
{
    public class GetCreateBloodRequestDataHandler
     : IRequestHandler<GetCreateBloodRequestDataQuery, CreateBloodRequestDataDto>
    {
        private readonly IHospitalRepository _hospitalRepo;
        private readonly IUnitOfWork unitOfWork;


        public GetCreateBloodRequestDataHandler(
            IHospitalRepository hospitalRepo,
            IUnitOfWork unitOfWork

            )
        {
            _hospitalRepo = hospitalRepo;
            this.unitOfWork = unitOfWork;

        }

        public async Task<CreateBloodRequestDataDto> Handle(
            GetCreateBloodRequestDataQuery request,
            CancellationToken cancellationToken)
        {
            var hospitals = await unitOfWork.HospitalRepository.GetAllAsync();
            var users = await unitOfWork.RecipientRepository.GetAllAsync();
            var technicians = await unitOfWork.LabTechnicianRepository.GetAllAsync();

            return new CreateBloodRequestDataDto
            {
                Hospitals = hospitals.Select(x => new DropdownItemDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),

                Recipients = users.Select(x => new DropdownItemDto
                {
                    Id = x.Id,
                    Name = x.FullName
                }).ToList(),

                LabTechnicians = technicians.Select(x => new DropdownItemDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),

                BloodGroups = Enum.GetNames(typeof(BloodGroup)).ToList()
            };
        }
    }
}
