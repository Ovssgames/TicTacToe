using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts
{
    [System.Serializable]
    public class Cell
    {
        public Button button;
        public Vector2Int coordinates;
        public Transform xSign;
        public Transform oSign;
    }
    
    public class GridUI : MonoBehaviour
    {
        [SerializeField] private List<Cell> _cells;

        private GridSystem _grid;
        private GameState _gameState;

        [Inject]
        private void Init(GridSystem grid, GameState gameState)
        {
            _grid = grid;
            _gameState = gameState;
        }

        private void Start()
        {
            foreach (var cell in _cells)
            {
                cell.button.onClick.AddListener(() => Click(cell));
            }
        }

        private void Click(Cell cell)
        {
            cell.button.enabled = false;
            
            _grid.SetSign(cell.coordinates.x, cell.coordinates.y);
            
            var signImage = _gameState.CurrentSign == SignType.X ? cell.xSign : cell.oSign; 
            signImage.gameObject.SetActive(true);
            Animations.AnimateSign(signImage);
        }
    }
}