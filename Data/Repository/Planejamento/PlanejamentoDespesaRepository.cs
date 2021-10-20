using Data.Context;
using Domain.Entities.Planejamento;
using Domain.Repository.Planejamento;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Planejamento
{
    public class PlanejamentoDespesaRepository : BaseRepository<PlanejamentoDespesasEntity>, IPlanejamentoDespesaRepository
    {
        private DbSet<PlanejamentoDespesasEntity> _dataset;

        public PlanejamentoDespesaRepository(CofrinhoContext context) : base(context)
        {
            _dataset = context.Set<PlanejamentoDespesasEntity>();
        }
    }
}
