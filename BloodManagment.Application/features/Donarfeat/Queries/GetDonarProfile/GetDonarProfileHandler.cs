using BloodManagment.Application.Commane;
using BloodManagment.Application.maping;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.Donarfeat.Queries.GetDonarProfile
{
    public class GetDonarProfileHandler
     : IRequestHandler<GetDonarProfileQuery, DonarVm>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDonarProfileHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        async Task<DonarVm> IRequestHandler<GetDonarProfileQuery, DonarVm>.Handle(GetDonarProfileQuery request, CancellationToken cancellationToken)
        {
            var donar = await _unitOfWork.DonarRepository.GetByIdAsync(request.Id);
            int numberOfRequestes =  _unitOfWork.DonationRequestRepository.GetDonarRequestnumberByDonerId(request.Id).Result;
            
            
            if (donar == null)
                return null;

            return new DonarVm
            {
                Id = donar.Id,
                FullName = donar.FullName,
                DonarCode = donar.DonarCode,
                BloodGroup = donar.BloodGroup.ToString(),
                Gender = donar.Gender.ToString(),
                LastDonationDate = donar.LastDonationDate,
                NextDonationDate = donar.NextDonationDate,
                DonationCount = donar.DonationCount,
                IsEilgibleToDonate = donar.IsEilgibleToDonate,
                DonationRequestesCount= numberOfRequestes
            };
        }
    }
}