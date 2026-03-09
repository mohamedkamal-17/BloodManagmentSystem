using AutoMapper;
using BloodManagment.Application.Commane;
using MediatR;

namespace BloodManagment.Application.features.BloodRequestfeat.Queries.GetBloodRequestDetails
{
    public class GetBloodRequestDetailsQueryHandler
      : IRequestHandler<GetBloodRequestDetailsQuery, BloodRequestDto>
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetBloodRequestDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {

            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }



        async Task<BloodRequestDto> IRequestHandler<GetBloodRequestDetailsQuery, BloodRequestDto>.Handle(GetBloodRequestDetailsQuery request, CancellationToken cancellationToken)
        {

            var requstes = await unitOfWork.BloodRequestRepository.GetByIdAsync(request.Id);


            return mapper.Map<BloodRequestDto>(requstes);
        }
    }
}
