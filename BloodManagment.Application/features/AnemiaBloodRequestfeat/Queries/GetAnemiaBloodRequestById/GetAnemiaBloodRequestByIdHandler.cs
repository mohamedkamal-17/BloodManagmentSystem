using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.AnemiaBloodRequestfeat.Queries.GetAnemiaBloodRequestById
{
    public class GetAnemiaBloodRequestByIdHandler
     : IRequestHandler<GetAnemiaBloodRequestByIdQuery, AnemiaBloodRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAnemiaBloodRequestByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AnemiaBloodRequest> Handle(
            GetAnemiaBloodRequestByIdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.AnemiaBloodRequestRepository
                .GetByIdAsync(request.Id);

            if (entity == null)
                return null;

            return entity;
        }
    }
}
