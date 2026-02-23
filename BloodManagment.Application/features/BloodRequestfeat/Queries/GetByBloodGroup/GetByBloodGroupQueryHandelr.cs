using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;
using System.Collections.ObjectModel;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetByBloodGroup
{
    public class GetByBloodGroupQueryHandelr : IRequestHandler<GetByBloodGroupQuery, ReadOnlyCollection<GetByBloodGroupDTO>>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GetByBloodGroupQueryHandelr(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }
        public async Task<ReadOnlyCollection<GetByBloodGroupDTO>> Handle(GetByBloodGroupQuery request, CancellationToken cancellationToken)
        {


            var requstes = await unitOfWorke.BloodRequestRepository.GetByBloodGroupAsync(request.BloodGroup);
            return mapper.Map<ReadOnlyCollection<GetByBloodGroupDTO>>(requstes);
        }
    }
}
