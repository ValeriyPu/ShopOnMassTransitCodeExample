using DatabaseItems;
using DataObjects.MassTransit.ConsumersRegistration;
using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace Warehouse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static ConsumerInfoProvider cip = new ConsumerInfoProvider();
        private static ConfigurationService mtconf = new ConfigurationService();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //Start one MassTransit service for every endpoint
                    var consumers = cip.ProcessAttributes();
                    var serverUrl = mtconf.Config.MassTransitConnectionParams;

                    var consumersAndEndpoints = consumers.GroupBy(item => item.QueueUri).Select(item => new { item.Key, item }).ToList();

                    foreach (var endp in consumersAndEndpoints)
                    {
                        services.AddMassTransit(x =>
                        {
                            var queueUri = endp.Key;

                            //TODO: add enpoints process
                            //x.AddEndpoint(new )

                            foreach (var consumer in consumers)
                            {
                                //TODO: add consumer registration (with services)
                                //x.AddConsumer(consumer.type);

                            }
                        });
                    };
                });
    }
}
