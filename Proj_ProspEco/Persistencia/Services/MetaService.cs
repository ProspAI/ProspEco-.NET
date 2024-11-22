using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Repositories;
using Proj_ProspEco.Persistencia.Services;

namespace Proj_ProspEco.Persistencia.Services
{
    public interface IMetaService : IService<Meta> { }

    public class MetaService : ServiceBase<Meta>, IMetaService
    {
        public MetaService(IMetaRepository repository) : base(repository) { }
    }
}
