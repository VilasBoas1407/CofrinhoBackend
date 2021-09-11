using Domain.DTO.Planejamento;
using Domain.Interfaces;
using Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Response response = await service.DoRegisterAsync(registerDTO);

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
