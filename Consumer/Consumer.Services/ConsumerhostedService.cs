using Consumer.Services.Model;
using Consumer.Services.Services;
using Core.AzureServiceBus;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Consumer.Services
{
    public class ConsumerhostedService : IHostedService, IDisposable
    {
       

        public ConsumerhostedService()
        {
           
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Started Hosted Service");
            var servis = new HelperServis();
            ConsumeQ<ReportModel>(BusConstants.directoryCreatedQueue, async item =>
            {
             var getmodel = await  servis.GetReport(item.Location);

                var updatemodel = new ReportUpdate();
                updatemodel.Status = 2;
                updatemodel.Id = item.Id;
                updatemodel.UserCount = getmodel.data.userCount;
                updatemodel.PhoneCount = getmodel.data.phoneCount;
                updatemodel.UptedTime =DateTime.Now;

                await servis.UpdateReport(updatemodel);   

            }).Wait();

      

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stopping Hosted Service");

            return Task.CompletedTask;
        }
        private Task OnProcess(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            Console.WriteLine("Dispossing...");
        }


        private static async Task ConsumeQ<T>(string qName, Action<T> receivedAction)
        {
            IQueueClient client = new QueueClient(BusConstants.ConnectionString, qName);

            client.RegisterMessageHandler(async (message, ct) =>
            {
                var model = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(message.Body));

                receivedAction(model);

                await Task.CompletedTask;
            },
            new MessageHandlerOptions(i => Task.CompletedTask));

            Console.WriteLine($"{typeof(T).Name} is listening....");
        }

        private static async Task ConsumeSub<T>(string topicName, string subName, Action<T> receivedAction)
        {
            ISubscriptionClient client = new SubscriptionClient(BusConstants.ConnectionString, topicName, subName);

            client.RegisterMessageHandler(async (message, ct) =>
            {
                var model = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(message.Body));

                receivedAction(model);

                await Task.CompletedTask;
            },
            new MessageHandlerOptions(i => Task.CompletedTask));

            Console.WriteLine($"{typeof(T).Name} is listening....");
        }
    }
}
