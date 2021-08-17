using Data.Context;
using Domain.Entities.Planejamento;
using Domain.Repository.Planejamento;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Planejamento
{

    public class PlanejamentoRepository : BaseRepository<PlanejamentoEntity>, IPlanejamentoRepository
    {
        private DbSet<PlanejamentoEntity> _dataset;

        public PlanejamentoRepository(CofrinhoContext context) : base(context)
        {
            _dataset = context.Set<PlanejamentoEntity>();
        }


    }
}
