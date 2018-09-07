using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Classes;


namespace Core.Classes.Tests
{
    [TestClass()]
    public class ParserTests
    {
        [TestMethod()]
        public void ParserTest()
        {
            
            Assert.Fail();
        }

        [TestMethod()]
        public void TextParserTest()
        {
            TextParser parser = new TextParser();
            parser.TextParser(null);
            Assert.AreEqual(0, parser._wordList.Count);
        }

        [TestMethod()]
        public void SortTest()
        {
            Assert.Fail();
        }
    }
}