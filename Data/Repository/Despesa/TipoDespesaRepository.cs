using Data.Context;
using Domain.Entities.Planejamento;
using Domain.Repository.Despesas;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Despesa
{
    public class TipoDespesaRepository : BaseRepository<TipoDespesaEntity>, ITipoDespesaRepository
    {
        private DbSet<TipoDespesaEntity> _dataset;

        public TipoDespesaRepository(CofrinhoContext context) : base(context)
        {
            _dataset = context.Set<TipoDespesaEntity>();
        }
    }
}
