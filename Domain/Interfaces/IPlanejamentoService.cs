using Domain.DTO.Planejamento;
using Domain.Utils;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPlanejamentoService
    {
        Task<Response> DoRegisterAsync(PlanejamentoRegisterDTO register);
    }
}
