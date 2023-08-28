using Student.DataAccess.Abstract;
using Student.DataAccess.Concrete.MsSql;
using Student.Entity;

namespace Student.DataAccess.Concrete
{
    public abstract class RepositoryBuilder<TEntity, TPrimary> where TEntity : BaseEntity<TPrimary>
    {
        public static IBaseRepository<TEntity, TPrimary> Builder
            (IBaseRepository<TEntity, TPrimary> repository, StudentDbContext dbContext)
        {
            return repository ??= new EfGenericRepository<TEntity, TPrimary>(dbContext);
        }
    }
}