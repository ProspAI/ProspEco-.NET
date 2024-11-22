using Proj_ProspEco.Data;
using Proj_ProspEco.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj_ProspEco.Persistencia.Repositories
{
    /// <summary>
    /// Interface para o repositório de Notificacao.
    /// </summary>
    public interface INotificacaoRepository : IRepository<Notificacao> { }

    /// <summary>
    /// Implementação do repositório para a entidade Notificacao.
    /// </summary>
    public class NotificacaoRepository : RepositoryBase<Notificacao>, INotificacaoRepository
    {
        private readonly ProspEcoDbContext _context;

        public NotificacaoRepository(ProspEcoDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todas as notificações de um usuário específico.
        /// </summary>
        /// <param name="usuarioId">ID do usuário.</param>
        public async Task<IEnumerable<Notificacao>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await Task.FromResult(_context.Notificacoes.Where(n => n.UsuarioId == usuarioId));
        }
    }
}
