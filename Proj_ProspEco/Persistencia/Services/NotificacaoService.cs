using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Repositories;

namespace Proj_ProspEco.Services
{
    public interface INotificacaoService : IService<Notificacao> { }

    public class NotificacaoService : ServiceBase<Notificacao>, INotificacaoService
    {
        public NotificacaoService(INotificacaoRepository repository) : base(repository) { }
    }
}
