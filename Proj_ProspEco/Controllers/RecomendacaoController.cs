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
    public class RecomendacaoController : ControllerBase
    {
        private readonly IRecomendacaoService _recomendacaoService;

        public RecomendacaoController(IRecomendacaoService recomendacaoService)
        {
            _recomendacaoService = recomendacaoService;
        }

        /// <summary>
        /// Obtém todas as recomendações.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recomendacao>>> GetAll()
        {
            var recomendacoes = await _recomendacaoService.GetAllAsync();
            return Ok(recomendacoes);
        }

        /// <summary>
        /// Obtém uma recomendação específica pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Recomendacao>> GetById(int id)
        {
            var recomendacao = await _recomendacaoService.GetByIdAsync(id);

            if (recomendacao == null)
                return NotFound(new { Message = "Recomendação não encontrada." });

            return Ok(recomendacao);
        }

        /// <summary>
        /// Obtém todas as recomendações de um usuário específico.
        /// </summary>
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Recomendacao>>> GetByUsuarioId(int usuarioId)
        {
            var recomendacoes = await _recomendacaoService.GetAllAsync();
            var recomendacoesUsuario = recomendacoes.Where(r => r.UsuarioId == usuarioId).ToList();

            if (!recomendacoesUsuario.Any())
                return NotFound(new { Message = "Nenhuma recomendação encontrada para o usuário informado." });

            return Ok(recomendacoesUsuario);
        }

        /// <summary>
        /// Cria uma nova recomendação.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Recomendacao>> Create(Recomendacao recomendacao)
        {
            if (recomendacao == null)
                return BadRequest(new { Message = "Dados inválidos para criar a recomendação." });

            await _recomendacaoService.AddAsync(recomendacao);

            return CreatedAtAction(nameof(GetById), new { id = recomendacao.Id_recom }, recomendacao);
        }

        /// <summary>
        /// Atualiza uma recomendação existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Recomendacao recomendacao)
        {
            if (id != recomendacao.Id_recom)
                return BadRequest(new { Message = "O ID informado não corresponde ao ID da recomendação." });

            var existe = await _recomendacaoService.GetByIdAsync(id);
            if (existe == null)
                return NotFound(new { Message = "Recomendação não encontrada." });

            await _recomendacaoService.UpdateAsync(recomendacao);

            return NoContent();
        }

        /// <summary>
        /// Deleta uma recomendação existente.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _recomendacaoService.GetByIdAsync(id);

            if (existe == null)
                return NotFound(new { Message = "Recomendação não encontrada." });

            await _recomendacaoService.DeleteAsync(id);

            return NoContent();
        }
    }
}
