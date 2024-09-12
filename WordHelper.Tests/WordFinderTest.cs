using System;
using Xunit;

namespace WordHelper.Tests
{
    public class WordFinderTest
    {
        [Fact]
        public void WordFinder_Test_Base()
        {
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

            Assert.Equal(result, new List<string> { "cold", "wind", "chill" });
        }

        [Fact]
        public void WordFinder_Test_More_Than_10_Words_Found()
        {
            List<string> matrix = new List<string>();

            matrix.Add("lalalala");
            matrix.Add("irarenan");
            matrix.Add("setendno");
            matrix.Add("toedotdn");
            matrix.Add("andototo");
            matrix.Add("rootonon");
            matrix.Add("elseimis");
            matrix.Add("zisnsuto");


            List<string> wordstream = new List<string>();

            wordstream.Add("lala");
            wordstream.Add("list");
            wordstream.Add("are");
            wordstream.Add("to");
            wordstream.Add("and");
            wordstream.Add("root");
            wordstream.Add("else");
            wordstream.Add("is");
            wordstream.Add("late");
            wordstream.Add("set");
            wordstream.Add("toe");
            wordstream.Add("dot");
            wordstream.Add("on");
            wordstream.Add("clear");


            WordFinder wordFinder = new WordFinder(matrix);
            IEnumerable<string> result = wordFinder.Find(wordstream);

            Assert.Equal(result, new List<string> { "to", "on", "are", "is", "lala", "and", "dot", "list", "root", "else" });
        }

        [Fact]
        public void WordFinder_Test_No_Words_Found()
        {
            List<string> matrix = new List<string>();

            matrix.Add("abcdc");
            matrix.Add("fgwio");
            matrix.Add("chill");
            matrix.Add("pqnsd");
            matrix.Add("uvdxy");

            List<string> wordstream = new List<string>();

            wordstream.Add("colder");
            wordstream.Add("windy");
            wordstream.Add("snowball");
            wordstream.Add("chilly");

            WordFinder wordFinder = new WordFinder(matrix);
            IEnumerable<string> result = wordFinder.Find(wordstream);

            Assert.Equal(result, new List<string> { });
        }

        [Fact]
        public void WordFinder_Test_Repeated_Words_In_Stream()
        {
            List<string> matrix = new List<string>();

            matrix.Add("abcdc");
            matrix.Add("fgwio");
            matrix.Add("chill");
            matrix.Add("pqnsd");
            matrix.Add("uvdxy");

            List<string> wordstream = new List<string>();

            wordstream.Add("cold");
            wordstream.Add("wind");
            wordstream.Add("cold");
            wordstream.Add("wind");

            WordFinder wordFinder = new WordFinder(matrix);
            IEnumerable<string> result = wordFinder.Find(wordstream);

            Assert.Equal(result, new List<string> { "cold", "wind" });
        }

        [Fact]
        public void WordFinder_Test_Matrix_Empty_Exception()
        {
            List<string> matrix = new List<string>();

            List<string> wordstream = new List<string>();

            Action act = () => new WordFinder(matrix);

            Exception ex = Assert.Throws<Exception>(() => act());
            Assert.Equal("matrix cannot be null or empty", ex.Message);
        }
    }
}