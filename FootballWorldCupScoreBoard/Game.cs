namespace FootballWorldCupScoreBoard
{
    public class Game
    {
        public string HomeTeam { get; set; }
        public int ScoreHomeTeam { get; set; } = 0;
        public string AwayTeam { get; set; }
        public int ScoreAwayTeam { get; set; } = 0;
        public GameState? State { get; set; }

        public enum GameState
        {
            Added,
            Started,
            Finished
        }
    }
}