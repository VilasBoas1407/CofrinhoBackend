using Domain.DTO.Planejamento;
using Domain.Entities.Planejamento;
using Domain.Utils;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IPlanejamentoService
    {
        Task<Response> DoRegisterAsync(PlanejamentoRegisterDTO register);

        PlanejamentoDTO GetPlanejamentoAtivoByUser(Guid idUser);

    }
}
