using BloodManagment.domain.Contracts.Repositorise;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.Application.features.Donarfeat.Queries.CheckDonorExistByUserId
{
    public class CheckDonorExistByUserIdQueryHandler : IRequestHandler<CheckDonorExistByUserIdQuery, bool>
    {
        private readonly IDonarRepository _donarRepository;

        public CheckDonorExistByUserIdQueryHandler(IDonarRepository donarRepository)
        {
            _donarRepository = donarRepository;
        }

        public async Task<bool> Handle(CheckDonorExistByUserIdQuery request, CancellationToken cancellationToken)
        {
            // Call the repository method to check if donor exists by UserId
            var donor = await _donarRepository.GetByUserIdAsync(request.UserId);

            // If donor is found, return true, otherwise false
            return donor != null;
        }
    }
}
