using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;

namespace BloodManagment.Application.features.Donarfeat.Queries.GetByUserId
{
    public class GetByUserIdQueryHandler : IRequestHandler<GetByUserIdQuery, DonarDto>
    {
        private readonly IUnitOfWork unitOfWorke;
        private readonly IMapper mapper;

        public GetByUserIdQueryHandler(IUnitOfWork unitOfWorke, IMapper mapper)
        {
            this.unitOfWorke = unitOfWorke;
            this.mapper = mapper;
        }
        public async Task<DonarDto> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var doner = await unitOfWorke.DonarRepository.GetByUserIdAsync(request.UserId);
            return mapper.Map<DonarDto>(doner);

        }
    }
}
