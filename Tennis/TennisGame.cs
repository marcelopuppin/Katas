using System;

namespace Katas
{
    public class TennisGame
    {
        private readonly int[] _pointsPlayer = new[] {0, 0};
        
        public string Score()
        {
            int pointsBetweenPlayers = Points(Player.One) - Points(Player.Two);
            if (Points(Player.One) == 0 && pointsBetweenPlayers == 0)
                return "love";
            if (BothPlayersMadeAtLeastThreePoints() && pointsBetweenPlayers == 0)
                return "deuce";
            if (BothPlayersMadeAtLeastThreePoints() && Math.Abs(pointsBetweenPlayers) == 1)
                return string.Format("advantage player {0}", (pointsBetweenPlayers > 0) ? "one" : "two");
            if (APlayerMadeAtLeastFourPoints() && Math.Abs(pointsBetweenPlayers) > 1)
                return string.Format("wins player {0}", (pointsBetweenPlayers > 0) ? "one" : "two");
            return string.Format("{0}-{1}", GetScoreBy(Player.One), GetScoreBy(Player.Two));
        }

        private bool APlayerMadeAtLeastFourPoints()
        {
            return Points(Player.One) > 3 || Points(Player.Two) > 3;
        }

        private bool BothPlayersMadeAtLeastThreePoints()
        {
            return Points(Player.One) >= 3 && Points(Player.Two) >= 3;
        }

        public void MakesAPoint(Player player)
        {
            int index = IndexByPlayer(player);
            _pointsPlayer[index]++;
        }

        private int Points(Player player)
        {
            int index = IndexByPlayer(player);
            return _pointsPlayer[index];
        }

        private static int IndexByPlayer(Player player)
        {
            if (player == Player.One)
            {
                return 0;
            }
            return 1;
        } 

        private string GetScoreBy(Player player)
        {
            switch(Points(player))
            {
                case 1:
                    return "fifteen";
                case 2:
                    return "thirty";
                case 3:
                    return "forty";
                default:
                    return "love";
            }
        }
    }

    public enum Player
    {
        One,
        Two
    }
}