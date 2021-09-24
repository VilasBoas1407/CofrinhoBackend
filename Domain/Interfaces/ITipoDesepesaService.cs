using Domain.DTO.Despesas;
using Domain.Utils;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITipoDesepesaService
    {
        Task<Response> DoRegisterAsync(TipoDespesaRegisterDTO register);
        Task<Response> GetAll(Guid idUser);
        Task<Response> GetByID(Guid id);
    }
}
