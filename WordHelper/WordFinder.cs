namespace WordHelper
{
    public class WordFinder
    {
        private List<string> _plainWordsList;

        public WordFinder(IEnumerable<string> matrix)
        {

            if (matrix == null || matrix.Count() == 0)
                throw new Exception("matrix cannot be null or empty");

            List<string> verticalWords = new List<string>(new string[matrix.First().Length]);

            // Converts a matrix of words to a list of words called _plainWordsList
            foreach (string word in matrix)
            {
                string verticalWord;

                for (int i = 0; i < word.Length; i++)
                {
                    verticalWord = verticalWords[i] + word[i];
                    verticalWords[i] = verticalWord;
                }
            }

            _plainWordsList = matrix.ToList();
            _plainWordsList.AddRange(verticalWords);
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            List<TopTenWord> topTenWords = new List<TopTenWord>();
            HashSet<string> verifiedWords = new HashSet<string>();

            // Searches each word of the wordstream
            foreach (var word in wordstream)
            {
                if (!verifiedWords.Contains(word))
                {
                    int count = 0;

                    foreach (var matrixWord in _plainWordsList)
                    {
                        count += CountWordOccurrences(matrixWord, word);
                    }

                    // Updates top ten list
                    if (count > 0)
                    {
                        UpdateTopTenList(word, count, topTenWords);
                    }

                    verifiedWords.Add(word);
                }
            }

            return topTenWords.Select(x => x.Word).ToList();

        }

        private int CountWordOccurrences(string word, string wordToFind)
        {
            // Counts occurrences of a word inside another one in a performant way

            int count = 0;

            for (int i = 0; i < word.Length - wordToFind.Length + 1; i++)
            {
                if (word.Substring(i, wordToFind.Length) == wordToFind)
                    count++;
            }

            return count;
        }

        private void UpdateTopTenList(string word, int count, List<TopTenWord> topTenWords)
        {
            // Update top ten list

            int lastTopTenCount = topTenWords.Count > 0 ? topTenWords[topTenWords.Count - 1].Count : 0;

            if ((topTenWords.Count < 10) || (count > lastTopTenCount))
            {
                int position;

                for (position = 0; position < topTenWords.Count; position++)
                {
                    if (count > topTenWords[position].Count)
                    {
                        break;
                    }
                }

                if (position <= 9)
                {
                    topTenWords.Insert(position, new TopTenWord { Word = word, Count = count });

                    if (topTenWords.Count > 10)
                        topTenWords.RemoveAt(10);
                }

            }
        }
    }
}
