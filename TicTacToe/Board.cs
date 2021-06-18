using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        private readonly Dictionary<Position, Player> _playedPositions = new();
        
        public GameStatus Place(Player player, Position position)
        {
            if (_playedPositions.ContainsKey(position))
            {
                throw new Exception();
            }

            _playedPositions[position] = player;

            return CalculateStatus();
        }

        private static readonly Tuple<Position, Position, Position>[] WinningCombinations = {
            new(Position.TopLeft, Position.TopCenter, Position.TopRight),
            new(Position.MiddleLeft, Position.MiddleCenter, Position.MiddleRight),
            new(Position.BottomLeft, Position.BottomCenter, Position.BottomRight),
            new(Position.TopLeft, Position.MiddleLeft, Position.BottomLeft),
            new(Position.TopCenter, Position.MiddleCenter, Position.BottomCenter),
            new(Position.TopRight, Position.MiddleRight, Position.BottomRight),
            new(Position.TopLeft, Position.MiddleCenter, Position.BottomRight),
            new(Position.BottomLeft, Position.MiddleCenter, Position.TopRight)
        };
        
        private GameStatus CalculateStatus()
        {
            var status = GameStatus.Open;
            
            foreach (var (position1, position2, position3) in WinningCombinations)
            {
                status = status != GameStatus.Open ? 
                    status : 
                    CheckWinningCombination(position1, position2, position3);
            }
            
            return AllPositionsPlayed() ? GameStatus.Draw : status;
        }

        private bool AllPositionsPlayed()
        {
            return _playedPositions.Count == 9;
        }

        private GameStatus CheckWinningCombination(Position position1, Position position2, Position position3)
        {
            _playedPositions.TryGetValue(position1, out var playerAt1);
            _playedPositions.TryGetValue(position2, out var playerAt2);
            _playedPositions.TryGetValue(position3, out var playerAt3);

            if (playerAt1 != null && playerAt1 == playerAt2 && playerAt2 == playerAt3)
            {
                return GameStatus.Winner(playerAt1);
            }

            return GameStatus.Open;
        }
    }
}