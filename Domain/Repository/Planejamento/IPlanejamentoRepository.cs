using Domain.Entities.Planejamento;
using System;
using System.Threading.Tasks;

namespace Domain.Repository.Planejamento
{
    public interface IPlanejamentoRepository : IRepository<PlanejamentoEntity>
    {
        PlanejamentoEntity GetPlanejamentoAtivoByUser(Guid idUser);     
    }
}
