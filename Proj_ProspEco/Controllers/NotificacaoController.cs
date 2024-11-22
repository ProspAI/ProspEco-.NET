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
    public class NotificacaoController : ControllerBase
    {
        private readonly IService<Notificacao> _notificacaoService;

        public NotificacaoController(IService<Notificacao> notificacaoService)
        {
            _notificacaoService = notificacaoService;
        }

        /// <summary>
        /// Obtém todas as notificações.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notificacao>>> GetAll()
        {
            var notificacoes = await _notificacaoService.GetAllAsync();
            return Ok(notificacoes);
        }

        /// <summary>
        /// Obtém uma notificação específica pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Notificacao>> GetById(int id)
        {
            var notificacao = await _notificacaoService.GetByIdAsync(id);

            if (notificacao == null)
                return NotFound(new { Message = "Notificação não encontrada." });

            return Ok(notificacao);
        }

        /// <summary>
        /// Obtém todas as notificações de um usuário específico.
        /// </summary>
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Notificacao>>> GetByUsuarioId(int usuarioId)
        {
            var notificacoes = await _notificacaoService.GetAllAsync();
            var notificacoesUsuario = notificacoes.Where(n => n.UsuarioId == usuarioId).ToList();

            if (!notificacoesUsuario.Any())
                return NotFound(new { Message = "Nenhuma notificação encontrada para o usuário informado." });

            return Ok(notificacoesUsuario);
        }

        /// <summary>
        /// Cria uma nova notificação.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Notificacao>> Create(Notificacao notificacao)
        {
            if (notificacao == null)
                return BadRequest(new { Message = "Dados inválidos para criar a notificação." });

            await _notificacaoService.AddAsync(notificacao);

            return CreatedAtAction(nameof(GetById), new { id = notificacao.Id_notificacao }, notificacao);
        }

        /// <summary>
        /// Atualiza uma notificação existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Notificacao notificacao)
        {
            if (id != notificacao.Id_notificacao)
                return BadRequest(new { Message = "O ID informado não corresponde ao ID da notificação." });

            var existe = await _notificacaoService.GetByIdAsync(id);
            if (existe == null)
                return NotFound(new { Message = "Notificação não encontrada." });

            await _notificacaoService.UpdateAsync(notificacao);

            return NoContent();
        }

        /// <summary>
        /// Deleta uma notificação existente.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _notificacaoService.GetByIdAsync(id);

            if (existe == null)
                return NotFound(new { Message = "Notificação não encontrada." });

            await _notificacaoService.DeleteAsync(id);

            return NoContent();
        }
    }
}
