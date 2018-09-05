using Core.Classes;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                args = new string[] { "41954-8.txt", "OrderedWords.txt" };
            }           

            try
            {
                TextReader textReader = new TextReader(args[0]);
                TextWriter textWriter = new TextWriter(args[1]);

                Parser parser = new Parser();
                parser.TextParser(textReader.Read());
                textWriter.Write(parser.Sort());
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);             
            }

            //Console.ReadKey();
        }
    }
}
