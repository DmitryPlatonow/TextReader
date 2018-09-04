using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Classes
{
    public class TextWriter
    {
        private string _filePath;

        public TextWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void Write(IEnumerable<IGrouping<char, KeyValuePair<string, int>>> sortWord)

        {
            string result;

            using (FileStream stream = new FileStream(_filePath, FileMode.OpenOrCreate))
            {

                using (StreamWriter sw = new StreamWriter(stream, Encoding.Default))
                {
                    foreach (var item in sortWord)
                    {
                        sw.WriteLine(item.Key.ToString());
                        foreach (var word in item)
                        {
                            sw.WriteLine($"{word.Key} --- {word.Value }");
                        }
                    }
                }
            }
            
        }
    }
}

