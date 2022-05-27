using Newtonsoft.Json;
using System.IO;

namespace Data
{
    public class BallDAO
    {
        private string fileName;

        public BallDAO(string fileName)
        {
            this.fileName = fileName;
        }

        public void write(DataApi ball)
        {
            using (StreamWriter file = File.AppendText($@"C:\jsonFiles\{fileName}"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, ball);
            }
        }

    }
}
