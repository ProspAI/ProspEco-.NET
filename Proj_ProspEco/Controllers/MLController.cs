using Microsoft.AspNetCore.Mvc;
using Proj_ProspEco.Persistencia.Services;
using System;

namespace Proj_ProspEco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MLController : ControllerBase
    {
        private readonly MLService _mlService;

        public MLController()
        {
            _mlService = new MLService();
        }

        /// <summary>
        /// Treina o modelo de ML com base nos dados fornecidos.
        /// </summary>
        [HttpPost("treinar")]
        public ActionResult TreinarModelo()
        {
            try
            {
                _mlService.TreinarModelo();
                return Ok(new { Message = "Modelo treinado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Erro ao treinar o modelo: {ex.Message}" });
            }
        }
    }
}