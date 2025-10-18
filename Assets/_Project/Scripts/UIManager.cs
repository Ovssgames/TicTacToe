using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts
{
    public class UIManager :  MonoBehaviour
    {
        [Header("Background Settings")]
        [SerializeField] private Image _background;
        [SerializeField] private float _duration = 0.5f;
        [Space]
        [SerializeField] Color _xColor;
        [SerializeField] Color _oColor;
        [Space]
        [Header("Text Settings")]
        [SerializeField] GameObject _xText;
        [SerializeField] GameObject _oText;
        [Header("Win Menu Settings")]
        [SerializeField] private GameObject _winMenu;
        [SerializeField] private TextMeshProUGUI _winMenuText;
        
        private GameState _gameState;
        
        [Inject]
        private void Init(GameState gameState)
        {
            _gameState = gameState;
        }

        private void Start()
        {
            StartValues();

            _gameState.OnCurrentSignChanged += ChangeColor;
            _gameState.OnCurrentSignChanged += ChangeText;

            _gameState.OnGameOver += HideText;
            _gameState.OnGameOver += ShowWinMenu;
        }


        private void OnDestroy()
        {
            _gameState.OnCurrentSignChanged -= ChangeColor;
            _gameState.OnCurrentSignChanged -= ChangeText;

            _gameState.OnGameOver -= HideText;
            _gameState.OnGameOver -= ShowWinMenu;
        }

        private void StartValues()
        {
            _background.color = _gameState.CurrentSign == SignType.X ? _xColor : _oColor;
            var newText = _gameState.CurrentSign == SignType.X ? _xText : _oText;
            newText.SetActive(true);
            
            _winMenu.SetActive(false);
        }
        
        private void HideText()
        {
            _xText.SetActive(false);
            _oText.SetActive(false);
        }

        private void ChangeColor()
        {
            Color newColor = _gameState.CurrentSign == SignType.X ? _xColor : _oColor;
            
            _background.DOColor(newColor, _duration).SetEase(Ease.OutBack);
        }

        private void ChangeText()
        {
            var newText = _gameState.CurrentSign == SignType.X ? _xText : _oText;
            var oldText = _gameState.CurrentSign == SignType.X ? _oText : _xText;
            
            newText.SetActive(true);
            Animations.AnimateSign(newText.transform);
            oldText.SetActive(false);
        }

        private void ShowWinMenu()
        {
            _winMenu.SetActive(true);
            Animations.AnimateSign(_winMenu.transform);
            _winMenuText.text = _gameState.Winner switch
            {
                "X" => "Крестики победили!",
                "O" => "Нолики победили!",
                _ => "Ничья"
            };
        }
    }
}