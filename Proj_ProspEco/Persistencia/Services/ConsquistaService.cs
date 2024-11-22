using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Repositories;
using Proj_ProspEco.Persistencia.Services;

namespace Proj_ProspEco.Persistencia.Services
{
    public interface IConquistaService : IService<Conquista> { }

    public class ConquistaService : ServiceBase<Conquista>, IConquistaService
    {
        public ConquistaService(IConquistaRepository repository) : base(repository) { }
    }
}
