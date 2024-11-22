using Microsoft.AspNetCore.Mvc;
using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj_ProspEco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConquistaController : ControllerBase
    {
        private readonly IService<Conquista> _conquistaService;

        public ConquistaController(IService<Conquista> conquistaService)
        {
            _conquistaService = conquistaService;
        }

        /// <summary>
        /// Obtém todas as conquistas.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conquista>>> GetAll()
        {
            var conquistas = await _conquistaService.GetAllAsync();
            return Ok(conquistas);
        }

        /// <summary>
        /// Obtém uma conquista específica pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Conquista>> GetById(int id)
        {
            var conquista = await _conquistaService.GetByIdAsync(id);

            if (conquista == null)
                return NotFound(new { Message = "Conquista não encontrada." });

            return Ok(conquista);
        }

        /// <summary>
        /// Obtém todas as conquistas de um usuário específico.
        /// </summary>
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Conquista>>> GetByUsuarioId(int usuarioId)
        {
            var conquistas = await _conquistaService.GetAllAsync();
            var conquistasUsuario = conquistas.Where(c => c.UsuarioId == usuarioId).ToList();

            if (!conquistasUsuario.Any())
                return NotFound(new { Message = "Nenhuma conquista encontrada para o usuário informado." });

            return Ok(conquistasUsuario);
        }

        /// <summary>
        /// Cria uma nova conquista.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Conquista>> Create(Conquista conquista)
        {
            if (conquista == null)
                return BadRequest(new { Message = "Dados inválidos para criar a conquista." });

            await _conquistaService.AddAsync(conquista);

            return CreatedAtAction(nameof(GetById), new { id = conquista.Id_conquista }, conquista);
        }

        /// <summary>
        /// Atualiza uma conquista existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Conquista conquista)
        {
            if (id != conquista.Id_conquista)
                return BadRequest(new { Message = "O ID informado não corresponde ao ID da conquista." });

            var existe = await _conquistaService.GetByIdAsync(id);
            if (existe == null)
                return NotFound(new { Message = "Conquista não encontrada." });

            await _conquistaService.UpdateAsync(conquista);

            return NoContent();
        }

        /// <summary>
        /// Deleta uma conquista existente.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _conquistaService.GetByIdAsync(id);

            if (existe == null)
                return NotFound(new { Message = "Conquista não encontrada." });

            await _conquistaService.DeleteAsync(id);

            return NoContent();
        }
    }
}
