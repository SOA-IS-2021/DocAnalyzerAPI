using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace DocAnalyzerAPI
{
    public class Program
    {
        public static IModel Channel;
        
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory{ Uri = new Uri("amqp://guest:guest@rabbitmq-server:5672/")  };
            var connection = factory.CreateConnection();
            Channel = connection.CreateModel();
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
