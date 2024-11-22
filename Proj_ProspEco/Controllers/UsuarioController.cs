using Microsoft.AspNetCore.Mvc;
using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj_ProspEco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll()
        {
            var usuarios = await _usuarioService.GetAllUsuarios();
            return Ok(usuarios);
        }

        /// <summary>
        /// Obtém um usuário específico pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);

            if (usuario == null)
                return NotFound(new { Message = "Usuário não encontrado." });

            return Ok(new UsuarioDTO
            {
                Id = usuario.Id_usuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                PontuacaoEconom = usuario.PontuacaoEconom
            });
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Usuario>> Create(Usuario usuario)
        {
            if (usuario == null)
                return BadRequest(new { Message = "Dados inválidos para criar o usuário." });

            await _usuarioService.AddAsync(usuario);

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id_usuario }, new UsuarioDTO
            {
                Id = usuario.Id_usuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                PontuacaoEconom = usuario.PontuacaoEconom
            });
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Usuario usuario)
        {
            if (id != usuario.Id_usuario)
                return BadRequest(new { Message = "O ID informado não corresponde ao ID do usuário." });

            var existe = await _usuarioService.GetByIdAsync(id);
            if (existe == null)
                return NotFound(new { Message = "Usuário não encontrado." });

            await _usuarioService.UpdateAsync(usuario);

            return NoContent();
        }

        /// <summary>
        /// Deleta um usuário existente.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _usuarioService.GetByIdAsync(id);

            if (existe == null)
                return NotFound(new { Message = "Usuário não encontrado." });

            await _usuarioService.DeleteAsync(id);

            return NoContent();
        }
    }
}
