using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Classes
{
    public class TextParser
    {
        private IList<string> _wordList;
        private IDictionary<string, int> _sortWords;

        private string _regPattern = @"[^a-zA-Z-]";

        public TextParser()
        {
            _wordList = new List<string>();
            _sortWords = new Dictionary<string, int>();
        }

        public void Parse(string text)
        {
            if (text != null)
            {
                var primitiveText = Regex.Replace(text, _regPattern, " ");
                _wordList = Regex.Split(primitiveText, @"\s+")
                    .Where(x =>x != "")
                    .Select(x=> x.ToLower())
                    .OrderBy(x => x)
                    .ToList();
            }

        }

        public IEnumerable<IOrderedEnumerable<KeyValuePair<string, int>>> Sort()
        {
            foreach (var word in _wordList)
            {
                if (_sortWords.ContainsKey(word))
                {
                    _sortWords[word] += 1;
                }
                else
                {
                    _sortWords.Add(word, 1);
                }
            }
            return  _sortWords
                .GroupBy(x => x.Key.ToString().First())
                .OrderBy(x => x.Key)
                .Select(x => x.OrderByDescending(y => y.Value))
                ;
        }
    }
}
