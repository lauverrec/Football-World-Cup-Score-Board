using Football_World_Cup_Score_Board.Objects;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game1 = new Game("Mexico", "Canada");
            var game2 = new Game("Spain", "Brazil");
            var game3 = new Game("Germany", "France");
            var game4 = new Game("Uruguay", "Italy");
            var game5 = new Game("Argentina", "Australia");

            List<Game> games = new List<Game>();
            games.Add(game1);
            games.Add(game2);
            games.Add(game3);
            games.Add(game4);
            games.Add(game5);

            game4.StartGame();
            game2.StartGame();
            game1.StartGame();
            game5.StartGame();
            game3.StartGame();

            game1.updateScore(6, 6);
            game2.updateScore(10, 2);
            game3.updateScore(0, 5);
            game4.updateScore(3, 1);
            game5.updateScore(6, 6);

            game1.EndGame();

            ScoreBoard scoreBoard = new ScoreBoard(games);

            scoreBoard.ShowCurrentScoreBoard();
            Console.WriteLine("\n\n");
            scoreBoard.ShowSummaryScoreBoard();
        }
    }
}

