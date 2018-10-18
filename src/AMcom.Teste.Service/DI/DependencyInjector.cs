using AMcom.Teste.DAL;
using AMcom.Teste.DAL.ContextoBanco.Banco;
using AMcom.Teste.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AMcom.Teste.Service.DI
{
    public class DependencyInjector
    {
        public static void Inject(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextAmcom>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IServicesUbs, UbsService>();
            services.AddScoped<IRespositoryUbs, UbsRepository>();
            services.AddScoped<ContextAmcom>();
        }
    }
}
