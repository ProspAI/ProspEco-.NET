using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj_ProspEco.Persistencia.Services
{
    public class UsuarioService : ServiceBase<Usuario>
    {
        private readonly IRepository<Usuario> _repository;

        public UsuarioService(IRepository<Usuario> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllUsuarios()
        {
            var usuarios = await _repository.GetAllAsync();
            return usuarios.Select(u => new UsuarioDTO
            {
                Id = u.Id_usuario, 
                Email = u.Email,
                Nome = u.Nome,
                PontuacaoEconom = u.PontuacaoEconom 
            });
        }
    }
}
