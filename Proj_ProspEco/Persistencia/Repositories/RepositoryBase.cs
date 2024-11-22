using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj_ProspEco.Persistencia.Repositories
{
    /// <summary>
    /// Classe base genérica para repositórios.
    /// </summary>
    /// <typeparam name="T">Tipo da entidade.</typeparam>
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// Construtor do RepositoryBase.
        /// </summary>
        /// <param name="context">Instância do DbContext.</param>
        protected RepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Adiciona uma nova entidade ao banco de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada.</param>
        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove uma entidade do banco de dados pelo ID.
        /// </summary>
        /// <param name="id">ID da entidade.</param>
        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Retorna todas as entidades.
        /// </summary>
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Retorna uma entidade pelo ID.
        /// </summary>
        /// <param name="id">ID da entidade.</param>
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Atualiza uma entidade existente.
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada.</param>
        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
