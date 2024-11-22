using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Repositories;

namespace Proj_ProspEco.Persistencia.Services
{
    public interface IRegistroConsumoService : IService<RegistroConsumo> { }

    public class RegistroConsumoService : ServiceBase<RegistroConsumo>, IRegistroConsumoService
    {
        public RegistroConsumoService(IRegistroConsumoRepository repository) : base(repository) { }
    }
}
