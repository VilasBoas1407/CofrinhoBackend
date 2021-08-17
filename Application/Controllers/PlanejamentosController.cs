using Domain.DTO.Planejamento;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/planejamento")]
    [ApiController]
    public class PlanejamentosController : ControllerBase
    {
        /// <summary>
        /// Gestão dos planejamentos
        /// </summary>
        /// <param name="registerDTO"></param>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public async Task<object> Register([FromBody] PlanejamentoRegisterDTO registerDTO, [FromServices] IPlanejamentoService service)
        {
            return BadRequest(ModelState);
        }
    }
}
