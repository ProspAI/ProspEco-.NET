using Microsoft.EntityFrameworkCore;

namespace Proj_ProspEco.Persistencia.Repositories
{
      public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class
      {
         public Repository(DbContext context) : base(context)
         {
         }
      }
 }
