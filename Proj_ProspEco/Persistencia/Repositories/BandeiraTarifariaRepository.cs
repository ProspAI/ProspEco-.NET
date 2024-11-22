using Proj_ProspEco.Data;
using Proj_ProspEco.Models;
using System.Threading.Tasks;

namespace Proj_ProspEco.Persistencia.Repositories
{
    /// <summary>
    /// Interface para o repositório de BandeiraTarifaria.
    /// </summary>
    public interface IBandeiraTarifariaRepository : IRepository<BandeiraTarifaria>
    {
        Task<BandeiraTarifaria> GetBandeiraVigenteAsync();
    }

    /// <summary>
    /// Implementação do repositório para a entidade BandeiraTarifaria.
    /// </summary>
    public class BandeiraTarifariaRepository : RepositoryBase<BandeiraTarifaria>, IBandeiraTarifariaRepository
    {
        private readonly ProspEcoDbContext _context;

        public BandeiraTarifariaRepository(ProspEcoDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna a bandeira tarifária vigente.
        /// </summary>
        public async Task<BandeiraTarifaria> GetBandeiraVigenteAsync()
        {
            return await Task.FromResult(_context.BandeirasTarifarias
                .OrderByDescending(b => b.DataVigencia)
                .FirstOrDefault());
        }
    }
}
