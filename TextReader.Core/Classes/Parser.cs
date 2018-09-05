using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Classes
{
    public class Parser
    {
        IList<string> _wordList;
        IDictionary<string, int> _sortWords;

        string[] separators = { " - ", ",", ".", "!", "?", ";", ":", " ", "\'",
                                "\"", "\r", "\n", "(", ")", "[", "]", "_",
                                "--", "/","#", "&", "$", "*", "@", "|", "+"};

        public Parser()
        {
            _wordList = new List<string>();
            _sortWords = new Dictionary<string, int>();
        }

        public void TextParser(string text)
        {
            _wordList = text.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .Where(x => x != "-")
                .OrderBy(x => x)                
                .ToList();
        }

        public IEnumerable<IOrderedEnumerable<KeyValuePair<string, int>>> SortByLiterAndCount()
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
            return _sortWords                
                .GroupBy(x => x.Key.First())
                .OrderBy(x => x.Key)
                .Select(x => x.OrderByDescending(y => y.Value));
            ;
                
        }
    }
}
