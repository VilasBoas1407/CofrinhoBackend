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
        Response DoRegister(PlanejamentoRegisterDTO register);
        Response DoUpdate(PlanejamentoEntity planejamento);
        PlanejamentoDTO GetPlanejamentoAtivoByUser(Guid IdUsuario);

        PlanejamentoEntity GetPlanejamentoComMesEAno(Guid IdUsuario, int MesReferencia, int AnoReferencia);
        bool HasPlanejamentoComMesEAno(Guid IdUsuario, int MesReferencia, int AnoReferencia);

        void UpdatePlanejamentoAtivo(PlanejamentoEntity planejamento);
    }
}
