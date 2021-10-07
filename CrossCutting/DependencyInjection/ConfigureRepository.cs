using Data.Context;
using Data.Repository;
using Data.Repository.Despesa;
using Data.Repository.Planejamento;
using Domain.Interfaces;
using Domain.Repository;
using Domain.Repository.Despesas;
using Domain.Repository.History;
using Domain.Repository.Planejamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<ILoginHistoryRepository, LoginHistoryRepository>();
            serviceCollection.AddTransient<IPlanejamentoRepository, PlanejamentoRepository>();
            serviceCollection.AddTransient<ITipoDespesaRepository, TipoDespesaRepository>();
            serviceCollection.AddTransient<IDespesaRepository, DespesaRepository>();

            serviceCollection.AddDbContext<CofrinhoContext>(
                options => options.UseSqlServer("Server=127.0.0.1;Database=DB_COFRINHO;User Id=sa;Password=123456;")
            );
        }
    }
}
