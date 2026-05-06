using BloodManagment.domain.Contracts.Repositorise;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.DonationRequestfeat.Queries.GetDonationRequestsByUserId
{

   
        public class GetDonationRequestsByUserIdQueryHandler : IRequestHandler<GetDonationRequestsByUserIdQuery, List<DonationRequestDto>>
        {
            private readonly IDonationRequestRepository _donationRequestRepository;

            public GetDonationRequestsByUserIdQueryHandler(IDonationRequestRepository donationRequestRepository)
            {
                _donationRequestRepository = donationRequestRepository;
            }

            public async Task<List<DonationRequestDto>> Handle(GetDonationRequestsByUserIdQuery request, CancellationToken cancellationToken)
            {
                // Fetch the DonationRequests with the Donar included
                var donationRequests = await _donationRequestRepository.GetByUserIdAsync(request.UserId);

                // Map the data to DTO
                var donationRequestDtos = new List<DonationRequestDto>();

                foreach (var donationRequest in donationRequests)
                {
                    donationRequestDtos.Add(new DonationRequestDto
                    {
                        Id = donationRequest.Id,
                        RequestCode = donationRequest.RequestCode,
                        RequestDate = donationRequest.RequestDate,
                        PreferredDonationDate = donationRequest.PreferredDonationDate,
                        Statu = donationRequest.Statu,
                        DonarName = donationRequest.Donar.FullName // Including Donar's FullName
                    });
                }
                return donationRequestDtos;
            }


        }
    
}
       