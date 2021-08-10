using Data.Context;
using Domain.Entities.History;
using Domain.Repository.History;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class LoginHistoryRepository : BaseRepository<LoginHistoryEntity>, ILoginHistoryRepository
    {
        private DbSet<LoginHistoryEntity> _dataset;

        public LoginHistoryRepository(CofrinhoContext context) : base(context)
        {
            _dataset = context.Set<LoginHistoryEntity>();
        }
    }
}
