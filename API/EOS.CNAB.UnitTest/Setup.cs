using EOS.CNAB.Domain.Interfaces;
using EOS.CNAB.Domain.Services;
using EOS.CNAB.InfraStructure.Context;
using EOS.CNAB.InfraStructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EOS.CNAB.UnitTest
{
    public class Setup : Xunit.Di.Setup
    {
        protected override void Configure()
        {
            ConfigureAppConfiguration((hostingContext, config) =>
            {
                #region Ativar a Injeção de dependência no XUnit

                bool reloadOnChange = hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", true);
                if (hostingContext.HostingEnvironment.IsDevelopment())
                    config.AddUserSecrets<Setup>(true, reloadOnChange);

                #endregion
            });

            ConfigureServices((context, services) =>
            {
                #region Localizar o arquivo appsettings.json

                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);

                #endregion

                #region Capturar a connectionstring do arquivo appsettings.json

                var root = configurationBuilder.Build();
                var connectionString = root.GetSection("ConnectionStrings").GetSection("CNAB").Value;

                #endregion

                #region Fazendo as injeção de dependência do projeto de teste

                //Injetando a connection string na classe SqlServerContext
                services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));

                //Injetando a classe UsuarioRepository na interface IUsuarioRepository
                services.AddTransient<IUsuarioRepository, UsuarioRepository>();

                //Injetando a classe UsuarioDomainService na interface IUsuarioDomainService
                services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();

                #endregion
            });
        }
    }
}
