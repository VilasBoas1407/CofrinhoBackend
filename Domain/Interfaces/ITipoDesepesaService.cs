using Domain.DTO.Despesas;
using Domain.Utils;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITipoDesepesaService
    {
        Task<Response> DoRegisterAsync(TipoDespesaRegisterDTO register);
        Response GetAll(Guid idUser);
        Task<Response> GetByID(Guid id);
        Task<Response> Delete(Guid id);
        Task<Response> DoUpdateAsync(TipoDespesaRegisterDTO update);
    }
}
