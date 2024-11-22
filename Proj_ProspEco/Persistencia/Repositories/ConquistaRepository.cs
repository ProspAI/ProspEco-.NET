using Proj_ProspEco.Data;
using Proj_ProspEco.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj_ProspEco.Persistencia.Repositories
{
    /// <summary>
    /// Interface para o repositório de Conquista.
    /// </summary>
    public interface IConquistaRepository : IRepository<Conquista> { }

    /// <summary>
    /// Implementação do repositório para a entidade Conquista.
    /// </summary>
    public class ConquistaRepository : RepositoryBase<Conquista>, IConquistaRepository
    {
        private readonly ProspEcoDbContext _context;

        public ConquistaRepository(ProspEcoDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todas as conquistas de um usuário específico.
        /// </summary>
        /// <param name="usuarioId">ID do usuário.</param>
        public async Task<IEnumerable<Conquista>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await Task.FromResult(_context.Conquistas.Where(c => c.UsuarioId == usuarioId));
        }
    }
}
