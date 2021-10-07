using Data.Context;
using Domain.Entities.Expenses;
using Domain.Repository.Despesas;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Despesa
{
    public class DespesaRepository : BaseRepository<DespesasEntity>, IDespesaRepository
    {
        private DbSet<DespesasEntity> _dataset;

        public DespesaRepository(CofrinhoContext context) : base(context)
        {
            _dataset = context.Set<DespesasEntity>();
        }
    }
}
