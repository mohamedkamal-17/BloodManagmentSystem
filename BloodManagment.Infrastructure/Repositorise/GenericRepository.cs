using BloodManagment.Application.Specefication;
using BloodManagment.domain.Contracts.Reposetorise;
using BloodManagment.Infrastructure.DataHelper;
using Microsoft.EntityFrameworkCore;

namespace BloodManagment.Infrastructure.Repositoris
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _applicationContext;
        protected readonly DbSet<T> _dbset;
        public GenericRepository(ApplicationContext context)
        {
            _applicationContext = context;
            _dbset = _applicationContext.Set<T>();


        }

        public async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
            _dbset.Remove(entity);
        }

        public void UpdateAsync(T entity)
        {
            _dbset.Update(entity);
        }

        protected IQueryable<T> ApplaySpacedication(Specefication<T> specefication)
        {
            return SpeceficationEvaluater.SpeceficationEvaluater.GetQuery(_dbset, specefication);
        }


    }
}
