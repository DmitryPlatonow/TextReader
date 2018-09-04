using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Classes
{
    public class Parser
    {
        IList<string> _wordList;
        IDictionary<string, int> _sortWords;

        string[] separators = { ",", ".", "!", "?", ";", ":", " ", "\'",
            "\"", "\r", "\n", "(", ")", "[", "]", "_", "--", "/",
            "#", "&", "$", "*", "@", "|", "+" };

        public Parser()
        {
            _wordList = new List<string>();
            _sortWords = new Dictionary<string, int>();
        }

        public void TextParser(string text)
        {
            _wordList = text.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .OrderBy(x => x)
                .ToList();
        }

        public IEnumerable<IGrouping<char, KeyValuePair<string, int>>> SortByLiterAndCount()
        {
            foreach (var word in _wordList)
            {
                if (_sortWords.ContainsKey(word.ToString()))
                {
                    _sortWords[word.ToString()] += 1;
                }
                else
                {
                    _sortWords.Add(word, 1);
                }               
            }
            return _sortWords.GroupBy(x => x.Key.First()).Select(x => x);
        }
    }
}
