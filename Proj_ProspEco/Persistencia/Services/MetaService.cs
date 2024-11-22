using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Repositories;

namespace Proj_ProspEco.Services
{
    public interface IMetaService : IService<Meta> { }

    public class MetaService : ServiceBase<Meta>, IMetaService
    {
        public MetaService(IMetaRepository repository) : base(repository) { }
    }
}
