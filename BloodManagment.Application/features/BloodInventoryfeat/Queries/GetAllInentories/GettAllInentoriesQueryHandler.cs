using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.BloodInventoryfeat.Queries.GetAllInentory
{
    internal class GettAllInentoriesQueryHandler : IRequestHandler<GettAllInentoriesQuery, ReadOnlyCollection<GettAllInentoriesDto>>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GettAllInentoriesQueryHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }



        public async Task<ReadOnlyCollection<GettAllInentoriesDto>> Handle(GettAllInentoriesQuery request, CancellationToken cancellationToken)
        {
            var inventories = await unitOfWorke.BloodInventoryRepository.GetAllAsync();
            return mapper.Map<ReadOnlyCollection<GettAllInentoriesDto>>(inventories);

        }
    }
}
