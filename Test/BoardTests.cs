using FootballWorldCupScoreBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class BoardTests
    {

        [TestMethod]
        public void TestAddGame()
        {
            var board = new Board();
        }

        [TestMethod]
        public void TestDoesNotStartWithUpper()
        {
            // Tests that we expect to return false.
            string[] words = { "alphabet", "zebra", "abc", "αυτοκινητοβιομηχανία", "государство",
                               "1234", ".", ";", " " };
            foreach (var word in words)
            {
                bool result = word.StartsWithUpper();
                Assert.IsFalse(result,
                       string.Format("Expected for '{0}': false; Actual: {1}",
                                     word, result));
            }
        }

    }
}