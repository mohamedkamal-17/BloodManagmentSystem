using BloodManagment.domain.Common;
using BloodManagment.Infrastructure.DataHelper;
using Microsoft.EntityFrameworkCore;

namespace BloodManagment.Infrastructure.Extension
{
    public static class ModelBuilderExtensions
    {

        public static ModelBuilder ApplyGlobalConfigurations(this ModelBuilder modelBuilder)
        {
            // Apply Soft Delete filter
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(ModelBuilderExtensions)
                        .GetMethod(nameof(SetSoftDeleteFilter), System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)
                        ?.MakeGenericMethod(entityType.ClrType);

                    method?.Invoke(null, new object[] { modelBuilder });
                }


            }

            // Apply all configurations in assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            return modelBuilder;
        }

        private static void SetSoftDeleteFilter<TEntity>(ModelBuilder builder)
            where TEntity : BaseEntity
        {
            builder.Entity<TEntity>().HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
