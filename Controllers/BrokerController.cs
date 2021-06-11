using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace DocAnalyzerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokerController : ControllerBase
    {
        [HttpGet]
        public void Get(string name)
        {
            var body = Encoding.UTF8.GetBytes(name);
            Program.Channel.ExchangeDeclare(exchange: "Document-Analyzer",
                type: ExchangeType.Fanout);
            Program.Channel.BasicPublish(exchange: "Document-Analyzer",
                routingKey: "",
                basicProperties: null,
                body: body);
            Console.WriteLine(" Message sent: " + name);
        }
    }
}
