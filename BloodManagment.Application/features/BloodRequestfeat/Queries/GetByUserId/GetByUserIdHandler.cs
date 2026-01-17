using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetByUserId
{
    public class GetByUserIdHandler : IRequestHandler<GetByUserIdQuery, ReadOnlyCollection<GetByUserIdDTO>>
    {
        private readonly IUnitOfWorke unitOfWorke;
        private readonly Mapper mapper;

        public GetByUserIdHandler(IUnitOfWorke unitOfWorke, Mapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }
        public async Task<ReadOnlyCollection<GetByUserIdDTO>> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var requstes = await unitOfWorke.BloodRequestRepository.GetByUserIdAsync(request.UserId);
            return mapper.Map<ReadOnlyCollection<GetByUserIdDTO>>(requstes);
        }
    }
}
