using System;

namespace TicTacToe
{
    public class Position
    {
        private readonly int _x;
        private readonly int _y;

        private Position(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public static readonly Position TopLeft = new(0, 0);
        public static readonly Position TopCenter = new(0, 1);
        public static readonly Position TopRight = new(0, 2);

        public static readonly Position MiddleLeft = new(1, 0);
        public static readonly Position MiddleCenter = new(1, 1);
        public static readonly Position MiddleRight = new(1, 2);

        public static readonly Position BottomLeft = new(2, 0);
        public static readonly Position BottomCenter = new(2, 1);
        public static readonly Position BottomRight = new(2, 2);

        private bool Equals(Position other)
        {
            return _x == other._x && _y == other._y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_x, _y);
        }

        public static bool operator ==(Position left, Position right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !Equals(left, right);
        }
    }
}