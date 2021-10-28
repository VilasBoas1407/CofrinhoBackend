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
        PlanejamentoDTO GetPlanejamentoAtivoByUser(Guid IdUsuario);

        PlanejamentoEntity BuscarPlanejamentoComMesEAno(Guid IdUsuario, int MesReferencia, int AnoReferencia);
        bool ExistePlanejamentoComMesEAno(Guid IdUsuario, int MesReferencia, int AnoReferencia);
    }
}
