using Newtonsoft.Json;
using System;
using System.IO;

namespace Data
{
    public class BallDAO
    {
        private string directory;

        public BallDAO()
        {
            this.directory = String.Format("{0}",
                                DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss")); ;
        }

        public void write(DataApi ball, int index)
        {
            Directory.CreateDirectory($@"./../../../../Logs/{directory}");
            using (StreamWriter file = File.AppendText($@"./../../../../Logs/{directory}/ball_{index}.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, ball);
                file.Write("\n");
                file.Close();
            }
        }

    }
}
