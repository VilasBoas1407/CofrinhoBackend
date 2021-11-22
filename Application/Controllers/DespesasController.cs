using Domain.DTO.Despesas;
using Domain.Interfaces;
using Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{

    [Route("api/despesa")]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        /// <summary>
        /// Registra uma nova despesa
        /// </summary>
        /// <param name="registerDTO"></param>
        /// <param name="service"></param>
        /// <response code="201">Despesa cadastrada com sucesso</response>
        /// <response code="400">Campos inválidos</response>
        /// <response code="401">Não autorizado</response>
        /// <response code="500">Erro interno</response>
        [Authorize("Bearer")]
        [HttpPost]
        public object Register([FromBody] DespesaDTO registerDTO, [FromServices] IDespesaService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Response response = service.DoRegister(registerDTO);

                if (response.StatusCode == 200)
                    return StatusCode(response.StatusCode, response.Result);
                else
                    return StatusCode(response.StatusCode, response.Message);

            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
