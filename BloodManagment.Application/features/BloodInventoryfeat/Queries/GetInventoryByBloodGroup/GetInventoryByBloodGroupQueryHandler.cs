using BloodManagment.Application.Commane;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.BloodInventoryfeat.Queries.GetInventoryByBloodGroup
{

    public class GetInventoryByBloodGroupQueryHandler
        : IRequestHandler<GetInventoryByBloodGroupQuery, GetInventoryByBloodGroupDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetInventoryByBloodGroupQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetInventoryByBloodGroupDto> Handle(
            GetInventoryByBloodGroupQuery request,
            CancellationToken cancellationToken)
        {
            var inventory = await _unitOfWork
                .BloodInventoryRepository
                .GetByBloodGroupAsync(request.BloodGroup);



            return new GetInventoryByBloodGroupDto()
            {
                Id = inventory.Id,
                BloodGroup = inventory.BloodGroup,
                Quantity = inventory.Quantity,
                Status = inventory.Status
            };


        
        }
    }
}
