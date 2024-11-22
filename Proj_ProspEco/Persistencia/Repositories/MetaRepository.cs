using Proj_ProspEco.Data;
using Proj_ProspEco.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj_ProspEco.Persistencia.Repositories
{
    /// <summary>
    /// Interface para o repositório de Meta.
    /// </summary>
    public interface IMetaRepository : IRepository<Meta> { }

    /// <summary>
    /// Implementação do repositório para a entidade Meta.
    /// </summary>
    public class MetaRepository : RepositoryBase<Meta>, IMetaRepository
    {
        private readonly ProspEcoDbContext _context;

        public MetaRepository(ProspEcoDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todas as metas de um usuário específico.
        /// </summary>
        /// <param name="usuarioId">ID do usuário.</param>
        public async Task<IEnumerable<Meta>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await Task.FromResult(_context.Metas.Where(m => m.UsuarioId == usuarioId));
        }
    }
}
