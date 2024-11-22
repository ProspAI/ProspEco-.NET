using Microsoft.AspNetCore.Mvc;
using Proj_ProspEco.Models;
using Proj_ProspEco.Persistencia.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Proj_ProspEco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecomendacoesController : ControllerBase
    {
        private readonly IService<Recomendacao> _recomendacaoService;

        public RecomendacoesController(IService<Recomendacao> recomendacaoService)
        {
            _recomendacaoService = recomendacaoService;
        }

        /// <summary>
        /// Retorna todas as recomendações.
        /// </summary>
        /// <returns>Lista de recomendações cadastradas no sistema.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todas as recomendações", Description = "Retorna todas as recomendações cadastradas.")]
        [SwaggerResponse(200, "Lista de recomendações retornada com sucesso.")]
        [SwaggerResponse(500, "Erro interno ao tentar recuperar as recomendações.")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var recomendacoes = await _recomendacaoService.GetAllAsync();
                return Ok(recomendacoes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        /// <summary>
        /// Retorna uma recomendação específica pelo ID.
        /// </summary>
        /// <param name="id">ID da recomendação.</param>
        /// <returns>Recomendação correspondente ao ID.</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca recomendação por ID", Description = "Retorna os detalhes de uma recomendação específica.")]
        [SwaggerResponse(200, "Recomendação encontrada.")]
        [SwaggerResponse(404, "Recomendação não encontrada.")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var recomendacao = await _recomendacaoService.GetByIdAsync(id);
                if (recomendacao == null) return NotFound("Recomendação não encontrada.");
                return Ok(recomendacao);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        /// <summary>
        /// Cria uma nova recomendação.
        /// </summary>
        /// <param name="recomendacao">Dados da recomendação a ser criada.</param>
        /// <returns>Recomendação criada com sucesso.</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova recomendação", Description = "Adiciona uma recomendação ao sistema.")]
        [SwaggerResponse(201, "Recomendação criada com sucesso.")]
        [SwaggerResponse(400, "Erro nos dados enviados.")]
        public async Task<IActionResult> Create([FromBody] Recomendacao recomendacao)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Dados inválidos.");
                await _recomendacaoService.AddAsync(recomendacao);
                return CreatedAtAction(nameof(GetById), new { id = recomendacao.Id_recom }, recomendacao);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza uma recomendação existente.
        /// </summary>
        /// <param name="recomendacao">Dados da recomendação a ser atualizada.</param>
        /// <returns>Resultado da operação.</returns>
        [HttpPut]
        [SwaggerOperation(Summary = "Atualiza uma recomendação", Description = "Atualiza os dados de uma recomendação existente.")]
        [SwaggerResponse(204, "Recomendação atualizada com sucesso.")]
        [SwaggerResponse(400, "Erro nos dados enviados.")]
        [SwaggerResponse(404, "Recomendação não encontrada.")]
        public async Task<IActionResult> Update([FromBody] Recomendacao recomendacao)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Dados inválidos.");
                await _recomendacaoService.UpdateAsync(recomendacao);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui uma recomendação existente.
        /// </summary>
        /// <param name="id">ID da recomendação a ser excluída.</param>
        /// <returns>Resultado da operação.</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui uma recomendação", Description = "Remove uma recomendação existente pelo ID.")]
        [SwaggerResponse(204, "Recomendação excluída com sucesso.")]
        [SwaggerResponse(404, "Recomendação não encontrada.")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _recomendacaoService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
