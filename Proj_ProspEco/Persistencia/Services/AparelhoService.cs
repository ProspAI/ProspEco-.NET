using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Repositories;
using Proj_ProspEco.Persistencia.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj_ProspEco.Persistencia.Services
{

    public interface IAparelhoService : IService<Aparelho>
    {
        Task<IEnumerable<Aparelho>> GetByUsuarioIdAsync(int usuarioId);
    }

    public class AparelhoService : ServiceBase<Aparelho>, IAparelhoService
    {
        private readonly IAparelhoRepository _aparelhoRepository;

        public AparelhoService(IAparelhoRepository aparelhoRepository) : base(aparelhoRepository)
        {
            _aparelhoRepository = aparelhoRepository;
        }

        public async Task<IEnumerable<Aparelho>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _aparelhoRepository.GetByUsuarioIdAsync(usuarioId);
        }
    }
}
