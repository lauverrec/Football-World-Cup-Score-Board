using FootballWorldCupScoreBoard;

namespace FootballWorldCupScoreBoardTest
{
    public class BoardUnitTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void TestAddGame(Game game1, Game game2, Game game3)
        {
            var board = new Board();

            Assert.True(board.Games.Count == 0);

            board.AddGameToBoard(game1);
            board.AddGameToBoard(game2);
            board.AddGameToBoard(game3);

            Assert.True(board.Games.Count == 3);
            
            foreach(var game in board.Games)
            {
                Assert.True(game.Key.State == Game.GameState.Added);
            }

            Assert.True(board.Games[game1] < board.Games[game2]);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TestStartGame(Game game1, Game game2, Game game3)
        {
            var board = new Board();
            
            board.AddGameToBoard(game1);
            board.AddGameToBoard(game2);
            board.AddGameToBoard(game3);

            board.StartGame(game1);

            Assert.True(board.Games.Count == 3);
            Assert.True(board.Games.Keys.FirstOrDefault()?.ScoreHomeTeam == 0 && board.Games.Keys.FirstOrDefault()?.ScoreAwayTeam == 0);
            Assert.True(board.Games.Keys.FirstOrDefault()?.State == Game.GameState.Started);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TesUpdatetGame(Game game1, Game game2, Game game3)
        {
            var board = new Board();
            
            board.AddGameToBoard(game1);
            board.AddGameToBoard(game2);
            board.AddGameToBoard(game3);
            
            board.StartGame(game1);
            
            board.UpdateScoreGame(game1, 1, 0);

            Assert.True(board.Games.Count == 3);
            Assert.True(board.Games.Keys.FirstOrDefault()?.ScoreHomeTeam == 1 && board.Games.Keys.FirstOrDefault()?.ScoreAwayTeam == 0);
            Assert.True(board.Games.Keys.FirstOrDefault()?.State == Game.GameState.Started);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TesFinishtGame(Game game1, Game game2, Game game3)
        {
            var board = new Board();
            board.AddGameToBoard(game1);
            board.AddGameToBoard(game2);
            board.AddGameToBoard(game3);

            board.StartGame(game1);

            board.FinishGame(game1);

            Assert.True(board.Games.Count == 3);
            Assert.True(board.Games.Keys.FirstOrDefault()?.State == Game.GameState.Finished);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TesGetSummaeryBoard(Game game1, Game game2, Game game3)
        {
            var board = new Board();
            
            board.AddGameToBoard(game2);
            board.AddGameToBoard(game1);
            board.AddGameToBoard(game3);

            var sortedGames = board.GetSummary();

            Assert.True(sortedGames.Count == 3);
            Assert.True(sortedGames[0] == game2);
            Assert.True(sortedGames[1] == game1);
            Assert.True(sortedGames[2] == game3);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TesGetSummaeryBoardWithFinishedGame(Game game1, Game game2, Game game3)
        {
            var board = new Board();

            board.AddGameToBoard(game2);
            board.AddGameToBoard(game1);
            board.AddGameToBoard(game3);

            Assert.True(board.Games.Count == 3);

            var sortedGames = board.GetSummary();

            Assert.True(sortedGames.Count == 3);
            Assert.True(sortedGames[0] == game2);
            Assert.True(sortedGames[1] == game1);
            Assert.True(sortedGames[2] == game3);

            sortedGames = board.GetSummary();

            board.FinishGame(game3);
            Assert.True(sortedGames.Count == 3);
        }



        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {
                    new Game()
                    {
                        HomeTeam = "Mexico",
                        AwayTeam = "Canada"
                    },
                    new Game()
                    {
                        HomeTeam = "Spain",
                        AwayTeam = "Brazil"
                    },
                    new Game()
                    {
                        HomeTeam = "Germany",
                        AwayTeam = "France"
                    }
                },
            };
    }
}