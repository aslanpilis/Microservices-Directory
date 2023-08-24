
using Core.AzureServiceBus;

using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Services
{
    internal class Program
    {
        private static string[] Arguments { get; set; }
        static async Task Main(string[] args)
        {
            Arguments = args;
            var host = Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(ConfigureHostConfiguration)
            .ConfigureServices(ConfigureServices) // Add ConfigureServices method to Host
            .Build();

            await host.RunAsync();
          
        }
        private static void ConfigureHostConfiguration(IConfigurationBuilder builder)
        {
            builder
                .AddEnvironmentVariables()
                .AddCommandLine(Arguments);
        }
        private static void ConfigureServices(HostBuilderContext hostBuilderContext,
         IServiceCollection serviceCollection)
        {
            

            serviceCollection.AddLogging();

     
            serviceCollection.AddHostedService<ConsumerhostedService>();
    
        }
    }
}
