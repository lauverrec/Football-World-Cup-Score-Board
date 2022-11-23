using System;
using Football_World_Cup_Score_Board;
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

            List<Game> gameList = new List<Game>();
            gameList.Add(game1);
            gameList.Add(game2);
            gameList.Add(game3);
            gameList.Add(game4);
            gameList.Add(game5);

            game1.updateScore(0, 5);
            game2.updateScore(10, 2);
            game3.updateScore(2, 2);
            game4.updateScore(6, 6);
            game5.updateScore(3, 1);

            var sortList = gameList.OrderBy(g => g.DateTime);

            foreach(var game in gameList)
            {
                Console.WriteLine($"{game.HomeTeam} - {game.AwayTeam}: {game.ScoreHomeTeam} - {game.ScoreAwayTeam}");
            }

            Console.WriteLine("\n\n");

            game1.updateScore(6, 6);
            game2.updateScore(10, 2);
            game3.updateScore(0, 5);
            game4.updateScore(3, 1);
            game5.updateScore(6, 6);

            foreach (var game in sortList)
            {
                Console.WriteLine($"{game.HomeTeam} {game.ScoreHomeTeam} - {game.AwayTeam} {game.ScoreAwayTeam}");
            }


        }
    }
}

