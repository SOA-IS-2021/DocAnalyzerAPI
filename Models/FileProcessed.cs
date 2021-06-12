namespace DocAnalyzerAPI.Models
{
    public class FileProcessed
    {
        public FileProcessed()
        {
        }

        public FileProcessed(string fileId)
        {
            fileID = fileId;
        }

        public FileProcessed(string fileId, string sentiment, string offensive, string employees)
        {
            fileID = fileId;
            this.sentiment = sentiment;
            this.offensive = offensive;
            this.employees = employees;
        }

        public string fileID { get; set; }
        public string sentiment { get; set; }
        public string offensive { get; set; }
        public string employees { get; set; }
    }
}