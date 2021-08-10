using Data.Context;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserRepository(CofrinhoContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

    }
}
