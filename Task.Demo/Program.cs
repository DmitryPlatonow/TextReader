using Core.Classes;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "41954-8.txt";
            string wrirtenFile = "OrderedWords.txt";

            TextReader textReader = new TextReader(filePath);
            TextWriter textWriter = new TextWriter(wrirtenFile);

            Parser parser = new Parser();
            parser.TextParser(textReader.Read());
            textWriter.Write(parser.Sort());

        }
    }
}
