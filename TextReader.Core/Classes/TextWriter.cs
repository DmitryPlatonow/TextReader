using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Classes
{
    public class TextWriter
    {
        private string _filePath;

        public TextWriter(string filePath)
        {
            _filePath = filePath;
        }

        public void Write(IEnumerable<IOrderedEnumerable<KeyValuePair<string, int>>> sortWord)

        {
           
            using (FileStream stream = new FileStream(_filePath, FileMode.OpenOrCreate))
            {

                using (StreamWriter sw = new StreamWriter(stream, Encoding.Default))
                {
                    foreach (var item in sortWord)
                    {
                        sw.WriteLine(item.First().Key.ToString().First());

                        string output;

                        foreach (var word in item)
                        {
                            output = String.Format("{0, -20} {1,8}", word.Key, word.Value);
                            sw.WriteLine(output);
                        }
                    }
                }
            }

        }
    }
}

