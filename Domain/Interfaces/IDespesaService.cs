using Domain.DTO.Despesas;
using Domain.Utils;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDespesaService
    {
        Response DoRegister(DespesaDTO register);
    }
}
