using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Service.Auth;
using Service.Despesa;
using Service.Planejamento;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAuthService, AuthService>();
            serviceCollection.AddTransient<IPlanejamentoService, PlanejamentoService>();
            serviceCollection.AddTransient<ITipoDesepesaService, TipoDespesaService>();
        }
    }
}
