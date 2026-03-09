using BloodManagment.Application.Specefication;
using BloodManagment.domain.Entities;

namespace BloodManagment.Infrastructure.Repositorise
{
    internal class GetBloodUnitByIdSpec : Specefication<BloodUnit>
    {
        private int id;

        public GetBloodUnitByIdSpec(int id) : base(x => x.Id == id)
        {

        }
    }
}