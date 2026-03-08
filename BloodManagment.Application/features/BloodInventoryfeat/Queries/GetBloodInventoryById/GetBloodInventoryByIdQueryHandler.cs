using BloodManagment.Application.Commane;
using BloodManagment.domain.Entities;
using MediatR;

namespace BloodManagment.Application.features.BloodInventoryfeat.Queries.GetBloodInventoryById
{
    class GetBloodInventoryByIdQueryHandler : IRequestHandler<GetBloodInventoryByIdQuery, BloodInventory>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBloodInventoryByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BloodInventory> Handle(
            GetBloodInventoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var inventory = await _unitOfWork
                .BloodInventoryRepository
                .GetByIdAsync(request.Id);

            return inventory;
        }
    }
}
