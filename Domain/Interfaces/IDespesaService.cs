using Domain.DTO.Despesas;
using Domain.Utils;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDespesaService
    {
        Task<Response> DoRegisterAsync(DespesaRegisterDTO register);
    }
}
