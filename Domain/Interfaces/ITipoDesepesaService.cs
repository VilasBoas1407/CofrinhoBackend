using Domain.DTO.Despesas;
using Domain.Utils;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITipoDesepesaService
    {
        Task<Response> DoRegisterAsync(TipoDespesaRegisterDTO register);
    }
}
