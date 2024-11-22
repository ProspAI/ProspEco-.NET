using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Repositories;
using Proj_ProspEco.Persistencia.Services;

namespace Proj_ProspEco.Persistencia.Services
{
    public interface INotificacaoService : IService<Notificacao> { }

    public class NotificacaoService : ServiceBase<Notificacao>, INotificacaoService
    {
        public NotificacaoService(INotificacaoRepository repository) : base(repository) { }
    }
}
