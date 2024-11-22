using Microsoft.AspNetCore.Mvc;
using Proj_ProspEco.Models;
using Proj_ProspEco.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj_ProspEco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetaController : ControllerBase
    {
        private readonly IService<Meta> _metaService;

        public MetaController(IService<Meta> metaService)
        {
            _metaService = metaService;
        }

        /// <summary>
        /// Obtém todas as metas.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meta>>> GetAll()
        {
            var metas = await _metaService.GetAllAsync();
            return Ok(metas);
        }

        /// <summary>
        /// Obtém uma meta específica pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Meta>> GetById(int id)
        {
            var meta = await _metaService.GetByIdAsync(id);

            if (meta == null)
                return NotFound(new { Message = "Meta não encontrada." });

            return Ok(meta);
        }

        /// <summary>
        /// Obtém todas as metas de um usuário específico.
        /// </summary>
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Meta>>> GetByUsuarioId(int usuarioId)
        {
            var metas = await _metaService.GetAllAsync();
            var metasUsuario = metas.Where(m => m.UsuarioId == usuarioId).ToList();

            if (!metasUsuario.Any())
                return NotFound(new { Message = "Nenhuma meta encontrada para o usuário informado." });

            return Ok(metasUsuario);
        }

        /// <summary>
        /// Cria uma nova meta.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Meta>> Create(Meta meta)
        {
            if (meta == null)
                return BadRequest(new { Message = "Dados inválidos para criar a meta." });

            await _metaService.AddAsync(meta);

            return CreatedAtAction(nameof(GetById), new { id = meta.Id_meta }, meta);
        }

        /// <summary>
        /// Atualiza uma meta existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Meta meta)
        {
            if (id != meta.Id_meta)
                return BadRequest(new { Message = "O ID informado não corresponde ao ID da meta." });

            var existe = await _metaService.GetByIdAsync(id);
            if (existe == null)
                return NotFound(new { Message = "Meta não encontrada." });

            await _metaService.UpdateAsync(meta);

            return NoContent();
        }

        /// <summary>
        /// Deleta uma meta existente.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _metaService.GetByIdAsync(id);

            if (existe == null)
                return NotFound(new { Message = "Meta não encontrada." });

            await _metaService.DeleteAsync(id);

            return NoContent();
        }
    }
}
