using DocAnalyzerAPI.Models;
using DocAnalyzerAPI.Services;

namespace DocAnalyzerAPI.Data
{
    public class DbManager
    {
        /**
         * Gets the file processed from Mongo DB
         */
        public string GetProcessedFile(string fileName)
        {
            return MongoService.Instance.FindProcessedFile(fileName);
        }

        /**
         * Uploads the file to the Mongo DB
         */
        public void PostProcessedFile(FileProcessed fileProcessed)
        {
            MongoService.Instance.InsertProcessedFile(fileProcessed);
        }
    }
}