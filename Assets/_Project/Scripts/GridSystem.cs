using System;
using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    public enum SignType {X, O}
    
    public class GridSystem : IInitializable,  IDisposable
    {
        
        
        public int[,] Grid { get; private set; }

        private GameState _gameState;
        private GridUI _gridUI;
        private CheckWinner _checkWinner;
        
        private GridSystem(GameState gameState, GridUI gridUI, CheckWinner checkWinner)
        {
            _gameState = gameState;
            _gridUI = gridUI;
            _checkWinner = checkWinner;
        }
        public void Initialize()
        {
            Grid = new int[3, 3];
            
            _gridUI.OnClicked += SetSign;
        }
        public void Dispose()
        {
            _gridUI.OnClicked -= SetSign;
        }

        private void SetSign(int line, int column)
        {
            Grid[line, column] = _gameState.CurrentSign == SignType.X ? -1 : 1;
            Debug.Log(Grid[line, column]);

            var winner = _checkWinner.Check(Grid);
            if (winner is "X" or "O" or "Draw")
            {
                _gameState.EndGame(winner);
                return;
            }
            
            _gameState.NextTurn();
        }
    }
}