using Microsoft.AspNetCore.Mvc;
using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proj_ProspEco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AparelhoController : ControllerBase
    {
        private readonly IService<Aparelho> _aparelhoService;

        public AparelhoController(IService<Aparelho> aparelhoService)
        {
            _aparelhoService = aparelhoService;
        }

        /// <summary>
        /// Obtém todos os aparelhos.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aparelho>>> GetAll()
        {
            var aparelhos = await _aparelhoService.GetAllAsync();
            return Ok(aparelhos);
        }

        /// <summary>
        /// Obtém um aparelho específico pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Aparelho>> GetById(int id)
        {
            var aparelho = await _aparelhoService.GetByIdAsync(id);

            if (aparelho == null)
                return NotFound(new { Message = "Aparelho não encontrado." });

            return Ok(aparelho);
        }

        /// <summary>
        /// Cria um novo aparelho.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Aparelho>> Create(Aparelho aparelho)
        {
            if (aparelho == null)
                return BadRequest(new { Message = "Dados inválidos para criar o aparelho." });

            await _aparelhoService.AddAsync(aparelho);

            return CreatedAtAction(nameof(GetById), new { id = aparelho.Id_aparelho }, aparelho);
        }

        /// <summary>
        /// Atualiza um aparelho existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Aparelho aparelho)
        {
            if (id != aparelho.Id_aparelho)
                return BadRequest(new { Message = "O ID informado não corresponde ao ID do aparelho." });

            var existe = await _aparelhoService.GetByIdAsync(id);
            if (existe == null)
                return NotFound(new { Message = "Aparelho não encontrado." });

            await _aparelhoService.UpdateAsync(aparelho);

            return NoContent();
        }

        /// <summary>
        /// Deleta um aparelho existente.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _aparelhoService.GetByIdAsync(id);

            if (existe == null)
                return NotFound(new { Message = "Aparelho não encontrado." });

            await _aparelhoService.DeleteAsync(id);

            return NoContent();
        }
    }
}
