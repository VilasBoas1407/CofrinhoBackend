using Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Domain.Repository;
using Domain.Repository.History;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<ILoginHistoryRepository, LoginHistoryRepository>();

            serviceCollection.AddDbContext<CofrinhoContext>(
                options => options.UseSqlServer("Server=127.0.0.1;Database=DB_COFRINHO;User Id=sa;Password=123456;")
            );
        }
    }
}
