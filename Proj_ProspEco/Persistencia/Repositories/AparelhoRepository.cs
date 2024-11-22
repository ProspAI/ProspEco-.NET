using Proj_ProspEco.Data;
using Proj_ProspEco.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj_ProspEco.Persistencia.Repositories
{
    /// <summary>
    /// Interface para o repositório de Aparelho.
    /// </summary>
    public interface IAparelhoRepository : IRepository<Aparelho>
    {
        Task<IEnumerable<Aparelho>> GetByUsuarioIdAsync(int usuarioId);
    }

    /// <summary>
    /// Implementação do repositório para a entidade Aparelho.
    /// </summary>
    public class AparelhoRepository : RepositoryBase<Aparelho>, IAparelhoRepository
    {
        private readonly ProspEcoDbContext _context;

        public AparelhoRepository(ProspEcoDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os aparelhos de um usuário específico.
        /// </summary>
        /// <param name="usuarioId">ID do usuário.</param>
        public async Task<IEnumerable<Aparelho>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await Task.FromResult(_context.Aparelhos.Where(a => a.UsuarioId == usuarioId));
        }
    }
}
