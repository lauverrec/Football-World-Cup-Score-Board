using static FootballWorldCupScoreBoard.Game;

namespace FootballWorldCupScoreBoard
{
    public class Board
    {
        public Dictionary<Game, DateTime> Games { get; set; } = new Dictionary<Game, DateTime>();

        public void AddGameToBoard(Game game)
        {
            if(checkGame(game))
            {
                Games.Add(game, DateTime.Now);
                game.State = GameState.Added;
            }
            else
            {
                throw new Exception("A problem occurred. The game is null");
            }
            
        }

        public void StartGame(Game game)
        {
            if(checkGame(game))
            {
                game.ScoreHomeTeam = 0;
                game.ScoreAwayTeam = 0;
                game.State = GameState.Started;
            }
            else
            {
                throw new Exception("A problem occurred. The game is null");
            }

        }

        public void FinishGame(Game game)
        {
            if (checkGame(game))
            {
                game.State = GameState.Finished;
            }
            else
            {
                throw new Exception("A problem occurred. The game is null");
            }
        }

        public void UpdateScoreGame(Game game, int scoreHomeTeam, int scoreAwayTeam)
        {
            if(checkGame(game) && scoreHomeTeam >= 0 && scoreAwayTeam >= 0)
            {
                game.ScoreHomeTeam = scoreHomeTeam;
                game.ScoreAwayTeam = scoreAwayTeam;
            }
            else
            {
                throw new Exception("A problem occurred. The params aren't valid.");
            }
        }

        public List<Game> GetSummary()
        {
            var sortedGames = from game in Games orderby game.Value ascending select game.Key;
            var result = sortedGames.ToList().FindAll(g => g.State != Game.GameState.Finished);

            return result;
        }

        private bool checkGame(Game game)
        {
            return game != null;
        }

    }
}
