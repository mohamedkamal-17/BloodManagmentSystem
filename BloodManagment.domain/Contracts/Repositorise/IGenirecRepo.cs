namespace BloodManagment.domain.Contracts.Reposetorise
{
    public interface IGenirecRepo<T> where T : class
    {
        public Task AddAsync(T entity);

        public void DeleteAsync(T entity);

        public void UpdateAsync(T entity);



    }
}
