using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetByRecipientId
{
    public class GetByRecipientIdHandler : IRequestHandler<GetByRecipientIdQuery, ReadOnlyCollection<BloodRequestDto>>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GetByRecipientIdHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }
        public async Task<ReadOnlyCollection<BloodRequestDto>> Handle(GetByRecipientIdQuery request, CancellationToken cancellationToken)
        {
            var requstes = await unitOfWorke.BloodRequestRepository.GetByRecipientIdAsync(request.UserId);
            return mapper.Map<ReadOnlyCollection<BloodRequestDto>>(requstes);
        }
    }
}
