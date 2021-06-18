using System;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTests
    {
        private readonly Game _game;

        public GameTests()
        {
            _game = new Game();
        }
        
        [Fact]
        public void Given_the_first_player_is_not_X_move_is_not_allowed()
        {
            Assert.Throws<Exception>(() => _game.Move(Player.O, Position.TopLeft));
        }

        [Fact]
        public void Given_the_second_player_is_an_X_move_is_not_allowed()
        {
            _game.Move(Player.X, Position.TopLeft);
            Assert.Throws<Exception>(() => _game.Move(Player.X, Position.TopCenter));
        }

        [Fact]
        public void Given_the_same_position_is_played_twice_move_is_not_allowed()
        {
            _game.Move(Player.X, Position.TopLeft);
            Assert.Throws<Exception>(() => _game.Move(Player.O, Position.TopLeft));
        }

        [Fact]
        public void Given_an_horizontal_top_line_is_done_by_X_game_is_over_and_X_wins()
        {
            _game.Move(Player.X, Position.TopLeft);
            _game.Move(Player.O, Position.MiddleLeft);
            _game.Move(Player.X, Position.TopCenter);
            _game.Move(Player.O, Position.MiddleCenter);
            Assert.Equal(GameStatus.XWins, _game.Move(Player.X, Position.TopRight));
        }
        
        [Fact]
        public void Given_an_horizontal_middle_line_is_done_by_X_game_is_over_and_X_wins()
        {
            _game.Move(Player.X, Position.MiddleRight);
            _game.Move(Player.O, Position.TopLeft);
            _game.Move(Player.X, Position.MiddleLeft);
            _game.Move(Player.O, Position.TopCenter);
            Assert.Equal(GameStatus.XWins, _game.Move(Player.X, Position.MiddleCenter));
        }
        
        [Fact]
        public void Given_an_horizontal_bottom_line_is_done_by_X_game_is_over_and_X_wins()
        {
            _game.Move(Player.X, Position.BottomRight);
            _game.Move(Player.O, Position.TopLeft);
            _game.Move(Player.X, Position.BottomLeft);
            _game.Move(Player.O, Position.TopCenter);
            Assert.Equal(GameStatus.XWins, _game.Move(Player.X, Position.BottomCenter));
        }
        
        [Fact]
        public void Given_a_vertical_left_line_is_done_by_X_game_is_over_and_X_wins()
        {
            _game.Move(Player.X, Position.TopLeft);
            _game.Move(Player.O, Position.MiddleCenter);
            _game.Move(Player.X, Position.MiddleLeft);
            _game.Move(Player.O, Position.MiddleRight);
            Assert.Equal(GameStatus.XWins, _game.Move(Player.X, Position.BottomLeft));
        }
        
        [Fact]
        public void Given_an_vertical_center_line_is_done_by_X_game_is_over_and_X_wins()
        {
            _game.Move(Player.X, Position.TopCenter);
            _game.Move(Player.O, Position.TopLeft);
            _game.Move(Player.X, Position.MiddleCenter);
            _game.Move(Player.O, Position.TopRight);
            Assert.Equal(GameStatus.XWins, _game.Move(Player.X, Position.BottomCenter));
        }
        
        [Fact]
        public void Given_a_vertical_right_line_is_done_by_X_game_is_over_and_X_wins()
        {
            _game.Move(Player.X, Position.TopRight);
            _game.Move(Player.O, Position.TopLeft);
            _game.Move(Player.X, Position.MiddleRight);
            _game.Move(Player.O, Position.TopCenter);
            Assert.Equal(GameStatus.XWins, _game.Move(Player.X, Position.BottomRight));
        }
        
        [Fact]
        public void Given_a_diagonal_from_top_left_line_is_done_by_X_game_is_over_and_X_wins()
        {
            _game.Move(Player.X, Position.TopLeft);
            _game.Move(Player.O, Position.MiddleLeft);
            _game.Move(Player.X, Position.MiddleCenter);
            _game.Move(Player.O, Position.TopRight);
            Assert.Equal(GameStatus.XWins, _game.Move(Player.X, Position.BottomRight));
        }
        
        [Fact]
        public void Given_a_diagonal_from_bottom_left_line_is_done_by_X_game_is_over_and_X_wins()
        {
            _game.Move(Player.X, Position.BottomLeft);
            _game.Move(Player.O, Position.TopLeft);
            _game.Move(Player.X, Position.MiddleCenter);
            _game.Move(Player.O, Position.TopCenter);
            Assert.Equal(GameStatus.XWins, _game.Move(Player.X, Position.TopRight));
        }

        [Fact]
        public void Given_all_positions_are_played_and_no_lines_are_made_game_is_over_with_a_draw()
        {
            _game.Move(Player.X, Position.TopLeft);
            _game.Move(Player.O, Position.TopCenter);
            _game.Move(Player.X, Position.MiddleLeft);
            
            _game.Move(Player.O, Position.BottomLeft);
            _game.Move(Player.X, Position.MiddleCenter);
            _game.Move(Player.O, Position.BottomRight);
            
            _game.Move(Player.X, Position.BottomCenter);
            _game.Move(Player.O, Position.MiddleRight);
            
            Assert.Equal(GameStatus.Draw, _game.Move(Player.X, Position.TopRight));
        }
    }
}