using System.Text;
using System.IO;

namespace Core.Classes
{
    public class TextReader
    {
        private string _filePath;

        public TextReader(string filePath)
        {
            _filePath = filePath;
        }

        public string Read()

        {
            string result;

            using (FileStream stream = new FileStream(_filePath, FileMode.Open))
            {

                using (StreamReader reader = new StreamReader(stream, Encoding.Default))
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }
    }
}
