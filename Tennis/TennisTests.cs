using NUnit.Framework;

namespace Katas
{
    [TestFixture]
    public class TennisTests
    {
        [Test]
        public void Given2Players_When_GameIsStarting_Then_ScoreIs_love()
        {
            var game = new TennisGame();
            Assert.That(game.Score(), Is.EqualTo("love"));
        }

        [Test]
        public void Given2Players_When_Player1MakesAPoint_Then_ScoreIs_fifteen_love()
        {
            var game = new TennisGame();
            game.MakesAPoint(Player.One);
            Assert.That(game.Score(), Is.EqualTo("fifteen-love"));
        }

        [Test]
        public void Given2Players_When_Player1MakesTwoPoints_Then_ScoreIs_thirty_love()
        {
            var game = new TennisGame();
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            Assert.That(game.Score(), Is.EqualTo("thirty-love"));
        }

        [Test]
        public void Given2Players_When_Player1MakesThreePoints_Then_ScoreIs_forty_love()
        {
            var game = new TennisGame();
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            Assert.That(game.Score(), Is.EqualTo("forty-love"));
        }

        [Test]
        public void Given2Players_When_Player1MakesThreePointsAndPlayer2MakesOnePoint_Then_ScoreIs_forty_fifteen()
        {
            var game = new TennisGame();
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            Assert.That(game.Score(), Is.EqualTo("forty-fifteen"));
        }

        [Test]
        public void Given2Players_When_Player1MakesThreePointsAndPlayer2MakesTwoPoints_Then_ScoreIs_forty_thirty()
        {
            var game = new TennisGame();
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.Two);
            Assert.That(game.Score(), Is.EqualTo("forty-thirty"));
        }

        [Test]
        public void Given2Players_When_Player1MakesTwoPointsAndPlayer2MakesTwoPoints_Then_ScoreIs_thirty_thirty()
        {
            var game = new TennisGame();
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.Two);
            Assert.That(game.Score(), Is.EqualTo("thirty-thirty"));
        }

        [Test]
        public void Given2Players_When_Player1MakesThreePointsAndPlayer2MakesThreePoints_Then_ScoreIs_deuce()
        {
            var game = new TennisGame();
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.Two);
            Assert.That(game.Score(), Is.EqualTo("deuce"));
        }

        [Test]
        public void Given2Players_When_Player1MakesFourPointsAndPlayer2MakesThreePointsAlternately_Then_ScoreIs_advantage_player_one()
        {
            var game = new TennisGame();
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.One);
            Assert.That(game.Score(), Is.EqualTo("advantage player one"));
        }

        [Test]
        public void Given2Players_When_Player1MakesThreePointsAndPlayer2MakesFourPointsAlternately_Then_ScoreIs_advantage_player_two()
        {
            var game = new TennisGame();
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.Two);
            Assert.That(game.Score(), Is.EqualTo("advantage player two"));
        }

        [Test]
        public void Given2Players_When_Player1MakesFivePointsAndPlayer2MakesThreePointsAlternately_Then_ScoreIs_wins_player_one()
        {
            var game = new TennisGame();
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            Assert.That(game.Score(), Is.EqualTo("wins player one"));
        }

        [Test]
        public void Given2Players_When_Player1MakesThreePointsAndPlayer2MakesFivePointsAlternately_Then_ScoreIs_wins_player_two()
        {
            var game = new TennisGame();
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.Two);
            game.MakesAPoint(Player.Two);
            Assert.That(game.Score(), Is.EqualTo("wins player two"));
        }

        [Test]
        public void Given2Players_When_Player1MakesFourPointsDirectly_Then_ScoreIs_wins_player_one()
        {
            var game = new TennisGame();
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            Assert.That(game.Score(), Is.EqualTo("wins player one"));
        }

        [Test]
        public void Given2Players_When_Player2MakesFourPointsDirectly_Then_ScoreIs_wins_player_two()
        {
            var game = new TennisGame();
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            game.MakesAPoint(Player.One);
            Assert.That(game.Score(), Is.EqualTo("wins player one"));
        }
    }
}
