using Domain.DTO.Planejamento;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/planejamento")]
    [ApiController]
    public class PlanejamentosController : ControllerBase
    {
        public async Task<object> Register([FromBody] PlanejamentoRegisterDTO registerDTO, [FromServices] IPlanejamentoService service)
        {
            return BadRequest(ModelState);
        }
    }
}
