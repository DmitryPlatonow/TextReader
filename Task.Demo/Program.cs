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
                args = new string[] { "", "" };
                Console.WriteLine("Enter the file name to process");
                args[0] = Console.ReadLine();
                Console.WriteLine("Enter the output file name");
                args[1] = Console.ReadLine();
            }

            try
            {
                TextReader textReader = new TextReader(args[0]);
                TextWriter textWriter = new TextWriter(args[1]);

                TextParser parser = new TextParser();
                parser.Parse(textReader.Read());
                textWriter.Write(parser.Sort());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);             
            }

            Console.WriteLine("The output file has been saved");
        }
    }
}
