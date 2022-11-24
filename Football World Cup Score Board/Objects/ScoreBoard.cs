using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_World_Cup_Score_Board.Objects
{
    public class ScoreBoard
    {
        public List<Game> Games { get; set; }

        public ScoreBoard(List<Game> games)
        {
            Games = games;
        }

        public void ShowCurrentScoreBoard()
        {
            foreach (var game in Games)
            {
                if(!game.Finished)
                {
                    Console.WriteLine($"{game.HomeTeam} - {game.AwayTeam}: {game.ScoreHomeTeam} - {game.ScoreAwayTeam}");
                }
            }

        }

        public void ShowSummaryScoreBoard()
        {
            var sortList = Games.OrderBy(g => g.DateTime);

            foreach (var game in Games)
            {
                Console.WriteLine($"{game.HomeTeam} {game.ScoreHomeTeam} - {game.AwayTeam} {game.ScoreAwayTeam}");
            }
        }
    }
}
