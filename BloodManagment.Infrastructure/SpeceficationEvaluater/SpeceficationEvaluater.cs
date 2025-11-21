using BloodManagment.Application.Specefication;

using Microsoft.EntityFrameworkCore;

namespace BloodManagment.Infrastructure.SpeceficationEvaluater
{
    internal static class SpeceficationEvaluater
    {
        internal static IQueryable<T> GetQuery<T>(IQueryable<T> inputQuery, Specefication<T> specefication) where T : class
        {
            var query = inputQuery;

            // Apply criteria
            if (specefication.Criatria is not null)
            {
                query = query.Where(specefication.Criatria);
            }

            // Apply includes
            query = specefication?.Includes?.Aggregate(query, (crunnt, includeExpression) => crunnt.Include(includeExpression));



            // Apply ordering

            if (specefication.OrderByExpression is not null)
            {
                query = query.OrderBy(specefication.OrderByExpression);
            }
            else if (specefication.OrderByDescendingExpression is not null)
            {
                query = query.OrderByDescending(specefication.OrderByDescendingExpression);
            }

            // Apply split query if needed
            if (specefication.IsSplitQuery)
            {
                query = query.AsSplitQuery();
            }

            return query;
        }
    }
}
