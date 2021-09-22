using Domain.DTO.Despesas;
using Domain.Interfaces;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/tipoDespesa")]
    [ApiController]
    public class TipoDespesaController : ControllerBase
    {
        /// <summary>
        /// Registra um tipo de despesa
        /// </summary>
        /// <response code="201">Tipo despesa cadastrado com sucesso</response>
        /// <response code="400">Campos inválidos</response>
        /// <response code="401">Não autorizado</response>
        /// <response code="500">Erro interno</response>
        [HttpPost]
        [Route("register")]
        public async Task<object> RegisterAsync([FromBody] TipoDespesaRegisterDTO userRegister, [FromServices] ITipoDesepesaService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Response response = await service.DoRegisterAsync(userRegister);

                return StatusCode(response.StatusCode, new { response.Message });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
