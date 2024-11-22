using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj_ProspEco.Services
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
