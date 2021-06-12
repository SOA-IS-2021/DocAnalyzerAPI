using System;
using System.Collections.Generic;
using System.Text;
using DocAnalyzerAPI.Data;
using DocAnalyzerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace DocAnalyzerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController
    {
        private static List<FileProcessed> files;
        
        private readonly ILogger<FileController> _logger;
        
        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        [Route("/processed-file")]
        public string GetProcessedFile(string fileName)
        {
            return new DbManager().GetProcessedFile(fileName);
        }

        [HttpPost]
        [Route("/processed-file")]
        public void PostProcessedFile(string fileID)
        {
            var body = Encoding.UTF8.GetBytes(fileID);
            Program.Channel.ExchangeDeclare(exchange: "Document-Analyzer",
                type: ExchangeType.Fanout);
            Program.Channel.BasicPublish(exchange: "Document-Analyzer",
                routingKey: "",
                basicProperties: null,
                body: body);
            Console.WriteLine(" Message sent: " + fileID);
            
            var file = new FileProcessed(fileID);
            new DbManager().PostProcessedFile(file);
        }
    }
}