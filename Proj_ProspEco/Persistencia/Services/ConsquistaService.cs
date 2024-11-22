using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Repositories;

namespace Proj_ProspEco.Services
{
    public interface IConquistaService : IService<Conquista> { }

    public class ConquistaService : ServiceBase<Conquista>, IConquistaService
    {
        public ConquistaService(IConquistaRepository repository) : base(repository) { }
    }
}
