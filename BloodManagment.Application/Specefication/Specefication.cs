using System.Linq.Expressions;

namespace BloodManagment.Application.Specefication
{
    public abstract class Specefication<TEntity> where TEntity : class
    {
        public Specefication(Expression<Func<TEntity, bool>> criatria)
        {
            this.Criatria = criatria;

        }


        public Expression<Func<TEntity, bool>>? Criatria { get; }

        public List<Expression<Func<TEntity, object>>>? Includes { get; private set; } = new();

        public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }

        public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }

        public bool IsSplitQuery { get; set; }

        private void AddIncluds(Expression<Func<TEntity, object>> includeExpression)
                                                                        => Includes.Add(includeExpression);

        private void AddOrderByExpressions(Expression<Func<TEntity, object>> orderByExpression)
                                                                        => OrderByExpression = orderByExpression;
        private void AddOrderByDescendingExpression(Expression<Func<TEntity, object>> orderByDescendingExpression)
                                                                        => OrderByDescendingExpression = orderByDescendingExpression;
    }
}
