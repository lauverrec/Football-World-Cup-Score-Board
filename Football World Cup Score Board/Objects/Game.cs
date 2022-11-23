using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_World_Cup_Score_Board.Objects
{
    public class Game
    {
        public string HomeTeam { get; set; }
        public int ScoreHomeTeam { get; set; } = 0;
        public string AwayTeam { get; set; }
        public int ScoreAwayTeam { get; set; } = 0;

        public bool Started { get; set; } = false;

        public bool Finished { get; set; } = false;

        public DateTime DateTime {get; set;}

        public Game(string homeTeam, string awayTeam)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            
        }

        public void StartGame()
        {
            Started = true;
            ScoreAwayTeam = 0;
            ScoreHomeTeam = 0;
            DateTime = DateTime.Now;
        }

        public void EndGame()
        {
            Started = false;
            Finished = true;
        }

        public void updateScore(int NewScoreHomeTeam, int NewScoreAwayTeam)
        {
            ScoreHomeTeam = NewScoreHomeTeam;
            ScoreAwayTeam = NewScoreAwayTeam;
        }


    }
}
