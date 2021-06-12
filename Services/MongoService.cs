using System;
using DocAnalyzerAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DocAnalyzerAPI.Services
{
    public class MongoService
    {
        public static readonly MongoService Instance = new MongoService();
        
        // your connection string
        private const string ConnectionString = "mongodb://devroot:devroot@mongo:27017";

        // Private constructor
        private MongoService() { }
        
        /**
         * Finds the file that matches the fileName
         */
        public string FindProcessedFile(string fileID)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase("DBdocs");
            var files = db.GetCollection<BsonDocument>("documents");

            var filter = Builders<BsonDocument>.Filter.Eq("fileID", fileID);
            var @event = files.Find(filter);
            var result = @event.First();
            return result.ToJson();
        }

        /**
         * Saves the processed file to Mongo DB
         */
        public void InsertProcessedFile(FileProcessed fileProcessed)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase("DBdocs");
            var files = db.GetCollection<FileProcessed>("documents");
            
            files.InsertOne(fileProcessed);
        }
    }
}