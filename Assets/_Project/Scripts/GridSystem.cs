using System;

namespace _Project.Scripts
{
    public enum SignType {X, O}
    
    public class GridSystem
    {
        private int[,] Grid { get; set; }
        public event Action OnGridChanged;

        private GameState _gameState;
        
        private GridSystem(GameState gameState)
        {
            Grid = new int[3, 3];
            
            _gameState = gameState;
        }
        
        public void SetSign(int line, int column)
        {
            Grid[line, column] = _gameState.CurrentSign == SignType.X ? -1 : 1;
            _gameState.ChangeCurrentSign();
            
            OnGridChanged?.Invoke();
        }
    }
}