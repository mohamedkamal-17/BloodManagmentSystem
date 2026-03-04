using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodManagment.domain.Contracts.Repositorise
{
    public interface IBloodUnitRepository:IGenericRepository<BloodUnit>
    {
        Task<int> GetCountAsync();
    }
}
