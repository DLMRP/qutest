
using WordHelper;


List<string> matrix = new List<string>();

matrix.Add("abcdc");
matrix.Add("fgwio");
matrix.Add("chill");
matrix.Add("pqnsd");
matrix.Add("uvdxy");

List<string> wordstream = new List<string>();

wordstream.Add("cold");
wordstream.Add("wind");
wordstream.Add("snow");
wordstream.Add("chill");

WordFinder wordFinder = new WordFinder(matrix);
IEnumerable<string> result = wordFinder.Find(wordstream);

Console.WriteLine("Top 10 words: \n");

foreach (string word in result)
{
    Console.WriteLine(word);
}

Console.ReadKey();