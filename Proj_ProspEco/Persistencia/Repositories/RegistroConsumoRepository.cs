using Proj_ProspEco.Data;
using Proj_ProspEco.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj_ProspEco.Persistencia.Repositories
{
    /// <summary>
    /// Interface para o repositório de RegistroConsumo.
    /// </summary>
    public interface IRegistroConsumoRepository : IRepository<RegistroConsumo> { }

    /// <summary>
    /// Implementação do repositório para a entidade RegistroConsumo.
    /// </summary>
    public class RegistroConsumoRepository : RepositoryBase<RegistroConsumo>, IRegistroConsumoRepository
    {
        private readonly ProspEcoDbContext _context;

        public RegistroConsumoRepository(ProspEcoDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os registros de consumo de um aparelho específico.
        /// </summary>
        /// <param name="aparelhoId">ID do aparelho.</param>
        public async Task<IEnumerable<RegistroConsumo>> GetByAparelhoIdAsync(int aparelhoId)
        {
            return await Task.FromResult(_context.RegistrosConsumo.Where(rc => rc.AparelhoId == aparelhoId));
        }
    }
}
