using Domain.DTO.Despesas;
using Domain.Interfaces;
using Domain.Utils;
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
