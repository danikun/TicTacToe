using System;

namespace TicTacToe
{
    public class GameStatus
    {
        private readonly bool _isOpen;
        private readonly Player _winner;

        private GameStatus(bool isOpen, Player winner)
        {
            _isOpen = isOpen;
            _winner = winner;
        }

        public static GameStatus Winner(Player player) => new(false, player);
        
        public static readonly GameStatus Open = new(true, null);
        public static GameStatus XWins = new(false, Player.X);
        public static GameStatus OWins = new(false, Player.O);
        public static GameStatus Draw = new(false, null);

        private bool Equals(GameStatus other)
        {
            return _isOpen == other._isOpen && Equals(_winner, other._winner);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((GameStatus) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_isOpen, _winner);
        }

        public static bool operator ==(GameStatus left, GameStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GameStatus left, GameStatus right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            if (this == Open) return nameof(Open);
            if (this == XWins) return nameof(XWins);
            if (this == OWins) return nameof(OWins);
            if (this == Draw) return nameof(Draw);
            
            return string.Empty;
        }
    }
}