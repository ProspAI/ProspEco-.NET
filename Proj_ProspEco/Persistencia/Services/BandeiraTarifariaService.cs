using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Repositories;
using System.Threading.Tasks;

namespace Proj_ProspEco.Services
{
    public interface IBandeiraTarifariaService
    {
        Task<BandeiraTarifaria> GetBandeiraVigenteAsync();
    }

    public class BandeiraTarifariaService : IBandeiraTarifariaService
    {
        private readonly IBandeiraTarifariaRepository _repository;

        public BandeiraTarifariaService(IBandeiraTarifariaRepository repository)
        {
            _repository = repository;
        }

        public async Task<BandeiraTarifaria> GetBandeiraVigenteAsync()
        {
            return await _repository.GetBandeiraVigenteAsync();
        }
    }
}
