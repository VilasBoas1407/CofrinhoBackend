using Domain.DTO;
using Domain.DTO.Login;
using Domain.Interfaces;
using Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Login na aplicação
        /// </summary>
        /// <response code="200">Usuário logado</response>
        /// <response code="401">Usuário não autorizado</response>
        /// <response code="400">Campos inválidos</response>
        /// <response code="500">Erro interno</response>
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<object> Login([FromBody] LoginRequestDTO loginDTO, [FromServices] IAuthService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Response response = await service.DoLoginAsync(loginDTO);

                if(response.StatusCode == 200)
                    return StatusCode(response.StatusCode, new { response.Data });
                else
                    return StatusCode(response.StatusCode, new { response.Message });

            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Registra novo usuário
        /// </summary>
        /// <response code="201">Usuário cadastrado com sucesso</response>
        /// <response code="400">Campos inválidos</response>
        /// <response code="500">Erro interno</response>
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<object> RegisterAsync([FromBody] UserRegisterRequestDTO userRegister, [FromServices] IAuthService service)
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
