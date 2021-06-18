namespace TicTacToe
{
    public class Player
    {
        private readonly char _symbol;

        private Player(char symbol)
        {
            _symbol = symbol;
        }

        public static readonly Player X = new('X');
        public static readonly Player O = new('O');

        private bool Equals(Player other)
        {
            return _symbol == other._symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            
            return obj.GetType() == GetType() && Equals((Player) obj);
        }

        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }

        public static bool operator ==(Player left, Player right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Player left, Player right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{_symbol}";
        }
    }
}