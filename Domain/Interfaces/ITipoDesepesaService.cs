using Domain.DTO.Despesas;
using Domain.Utils;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITipoDesepesaService
    {
        Response DoRegister(TipoDespesaDTO register);
        Response GetAll(Guid idUser);
        Response GetByID(Guid id);
        Response Delete(Guid id);
        Response DoUpdate(TipoDespesaDTO update);
    }
}
