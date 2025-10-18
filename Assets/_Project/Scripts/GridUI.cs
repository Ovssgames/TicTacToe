using System;
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
        public event Action<int, int> OnClicked;
        
        [SerializeField] private List<Cell> _cells;

        private GameState _gameState;

        [Inject]
        private void Init(GameState gameState)
        {
            _gameState = gameState;
        }

        private void Start()
        {
            foreach (var cell in _cells)
            {
                cell.button.onClick.AddListener(() => Click(cell));
            }

            _gameState.OnGameOver += DeactivateButtons;
        }

        private void OnDestroy()
        {
            _gameState.OnGameOver -= DeactivateButtons;
        }

        private void DeactivateButtons()
        {
            foreach (var cell in _cells)
                cell.button.interactable = false;
        }

        private void Click(Cell cell)
        {
            cell.button.interactable = false;
            
            var signImage = _gameState.CurrentSign == SignType.X ? cell.xSign : cell.oSign; 
            signImage.gameObject.SetActive(true);
            Animations.AnimateSign(signImage);
            
            OnClicked?.Invoke(cell.coordinates.x, cell.coordinates.y);
        }
    }
}