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
    public class BandeiraTarifariaController : ControllerBase
    {
        private readonly IService<BandeiraTarifaria> _bandeiraTarifariaService;

        public BandeiraTarifariaController(IService<BandeiraTarifaria> bandeiraTarifariaService)
        {
            _bandeiraTarifariaService = bandeiraTarifariaService;
        }

        /// <summary>
        /// Obtém todas as bandeiras tarifárias.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BandeiraTarifaria>>> GetAll()
        {
            var bandeiras = await _bandeiraTarifariaService.GetAllAsync();
            return Ok(bandeiras);
        }

        /// <summary>
        /// Obtém uma bandeira tarifária específica pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<BandeiraTarifaria>> GetById(int id)
        {
            var bandeira = await _bandeiraTarifariaService.GetByIdAsync(id);

            if (bandeira == null)
                return NotFound(new { Message = "Bandeira tarifária não encontrada." });

            return Ok(bandeira);
        }

        /// <summary>
        /// Obtém a bandeira tarifária vigente (com a data de vigência mais recente).
        /// </summary>
        [HttpGet("vigente")]
        public async Task<ActionResult<BandeiraTarifaria>> GetBandeiraVigente()
        {
            var bandeiras = await _bandeiraTarifariaService.GetAllAsync();
            var vigente = bandeiras.OrderByDescending(b => b.DataVigencia).FirstOrDefault();

            if (vigente == null)
                return NotFound(new { Message = "Nenhuma bandeira tarifária vigente encontrada." });

            return Ok(vigente);
        }

        /// <summary>
        /// Cria uma nova bandeira tarifária.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<BandeiraTarifaria>> Create(BandeiraTarifaria bandeira)
        {
            if (bandeira == null)
                return BadRequest(new { Message = "Dados inválidos para criar a bandeira tarifária." });

            await _bandeiraTarifariaService.AddAsync(bandeira);

            return CreatedAtAction(nameof(GetById), new { id = bandeira.Id_bandeira }, bandeira);
        }

        /// <summary>
        /// Atualiza uma bandeira tarifária existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, BandeiraTarifaria bandeira)
        {
            if (id != bandeira.Id_bandeira)
                return BadRequest(new { Message = "O ID informado não corresponde ao ID da bandeira tarifária." });

            var existe = await _bandeiraTarifariaService.GetByIdAsync(id);
            if (existe == null)
                return NotFound(new { Message = "Bandeira tarifária não encontrada." });

            await _bandeiraTarifariaService.UpdateAsync(bandeira);

            return NoContent();
        }

        /// <summary>
        /// Deleta uma bandeira tarifária existente.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _bandeiraTarifariaService.GetByIdAsync(id);

            if (existe == null)
                return NotFound(new { Message = "Bandeira tarifária não encontrada." });

            await _bandeiraTarifariaService.DeleteAsync(id);

            return NoContent();
        }
    }
}
