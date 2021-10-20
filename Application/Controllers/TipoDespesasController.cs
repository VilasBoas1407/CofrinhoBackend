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
    [Route("api/tipoDespesa")]
    [ApiController]
    public class TipoDespesasController : ControllerBase
    {

        /// <summary>
        /// Registra um tipo de despesa
        /// </summary>
        /// <response code="201">Tipo despesa cadastrado com sucesso</response>
        /// <response code="400">Campos inválidos</response>
        /// <response code="401">Não autorizado</response>
        /// <response code="500">Erro interno</response>
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<object> Register([FromBody] TipoDespesaDTO tipoDespesaRegister, [FromServices] ITipoDesepesaService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Response response = await service.DoRegisterAsync(tipoDespesaRegister);

                return StatusCode(response.StatusCode, new { response.Message });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<object> Update([FromBody] TipoDespesaDTO tipoDespesaRegister, [FromServices] ITipoDesepesaService service)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Response response = await service.DoUpdateAsync(tipoDespesaRegister);
                return StatusCode(response.StatusCode, new { response.Message });
            }
            catch (Exception e )
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Retorna todos os tipos de despesas cadastradas
        /// </summary>
        /// <response code="200">Despesas encontradas</response>
        /// <response code="204">Não foram encontrada despesas</response>
        /// <response code="401">Não autorizado</response>
        /// <response code="500">Erro interno</response>
        [Authorize("Bearer")]
        [HttpGet]
        [Route("{idUser}")]
        public object GetAll([FromRoute] Guid idUser, [FromServices] ITipoDesepesaService service)
        {
            try
            {
                Response response =  service.GetAll(idUser);

                if (response.StatusCode == 200)
                    return StatusCode(response.StatusCode , response.Result);

                return StatusCode(response.StatusCode, new { response.Message });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Retorna todos os tipos de despesas cadastradas
        /// </summary>
        /// <response code="200">Despesas encontradas</response>
        /// <response code="204">Não foram encontrada despesas</response>
        /// <response code="401">Não autorizado</response>
        /// <response code="500">Erro interno</response>
        [Authorize("Bearer")]
        [HttpGet]
        [Route("GetById{id}")]
        public async Task<object> GetByID([FromRoute] Guid id, [FromServices] ITipoDesepesaService service)
        {
            try
            {
                Response response = await service.GetByID(id);

                if (response.StatusCode == 200)
                    return StatusCode(response.StatusCode, response.Result);

                return StatusCode(response.StatusCode, new { response.Message });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Deleta o tipo de despesa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="service"></param>
        /// <returns>
        /// <response code="200">Excluído</response>
        /// <response code="409">Tipo despesa está vinculado a alguma despesa</response>
        /// </returns>
        [Authorize("Bearer")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete([FromRoute] Guid id, [FromServices] ITipoDesepesaService service)
        {
            try
            {
                Response response = await service.Delete(id);

                if (response.StatusCode == 200)
                    return StatusCode(response.StatusCode, new { response.Message });

                return StatusCode(response.StatusCode, new { response.Message });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
