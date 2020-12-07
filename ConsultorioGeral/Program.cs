using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ConsultorioGeral.Data;
using ConsultorioGeral.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultorioGeral
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<PacienteContext>();
                    PacienteDbInitializer.Initialize(context);
                    MedicoDbInitializer.Initialize(context);
                    ConsultaDbInitializer.Initialize(context);


                }
                catch (Exception e)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "Um erro ao criar a base de dados");
                }
                host.Run();

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    
                    
                });
    }
}
//