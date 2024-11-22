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
    public class RegistroConsumoController : ControllerBase
    {
        private readonly IRegistroConsumoService _registroConsumoService;

        public RegistroConsumoController(IRegistroConsumoService registroConsumoService)
        {
            _registroConsumoService = registroConsumoService;
        }

        /// <summary>
        /// Obtém todos os registros de consumo.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroConsumo>>> GetAll()
        {
            var registros = await _registroConsumoService.GetAllAsync();
            return Ok(registros);
        }

        /// <summary>
        /// Obtém um registro de consumo específico pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroConsumo>> GetById(int id)
        {
            var registro = await _registroConsumoService.GetByIdAsync(id);

            if (registro == null)
                return NotFound(new { Message = "Registro de consumo não encontrado." });

            return Ok(registro);
        }

        /// <summary>
        /// Obtém todos os registros de consumo de um aparelho específico.
        /// </summary>
        [HttpGet("aparelho/{aparelhoId}")]
        public async Task<ActionResult<IEnumerable<RegistroConsumo>>> GetByAparelhoId(int aparelhoId)
        {
            var registros = await _registroConsumoService.GetAllAsync();
            var registrosAparelho = registros.Where(rc => rc.AparelhoId == aparelhoId).ToList();

            if (!registrosAparelho.Any())
                return NotFound(new { Message = "Nenhum registro de consumo encontrado para o aparelho informado." });

            return Ok(registrosAparelho);
        }

        /// <summary>
        /// Cria um novo registro de consumo.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<RegistroConsumo>> Create(RegistroConsumo registro)
        {
            if (registro == null)
                return BadRequest(new { Message = "Dados inválidos para criar o registro de consumo." });

            await _registroConsumoService.AddAsync(registro);

            return CreatedAtAction(nameof(GetById), new { id = registro.Id_registro }, registro);
        }

        /// <summary>
        /// Atualiza um registro de consumo existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, RegistroConsumo registro)
        {
            if (id != registro.Id_registro)
                return BadRequest(new { Message = "O ID informado não corresponde ao ID do registro de consumo." });

            var existe = await _registroConsumoService.GetByIdAsync(id);
            if (existe == null)
                return NotFound(new { Message = "Registro de consumo não encontrado." });

            await _registroConsumoService.UpdateAsync(registro);

            return NoContent();
        }

        /// <summary>
        /// Deleta um registro de consumo existente.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _registroConsumoService.GetByIdAsync(id);

            if (existe == null)
                return NotFound(new { Message = "Registro de consumo não encontrado." });

            await _registroConsumoService.DeleteAsync(id);

            return NoContent();
        }
    }
}
