using System;

namespace TicTacToe
{
    public class Game
    {
        private Player _currentPlayer;
        private readonly Board _board;
        
        public Game()
        {
            _currentPlayer = Player.X;
            _board = new Board();
        }
        
        public GameStatus Move(Player player, Position position)
        {
            if (player != _currentPlayer)
            {
                throw new Exception();
            }

            var status = _board.Place(player, position);
            SwitchPlayers();
            
            return status;
        }

        private void SwitchPlayers()
        {
            _currentPlayer = _currentPlayer == Player.X ? Player.O : Player.X;
        }
    }
}