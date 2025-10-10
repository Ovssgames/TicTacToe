using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts
{
    public class BackgroundChanger :  MonoBehaviour
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
        
        
        private GameState _gameState;
        
        
        [Inject]
        private void Init(GameState gameState)
        {
            _gameState = gameState;
        }

        private void Start()
        {
            _background.color = _gameState.CurrentSign == SignType.X ? _oColor : _xColor;
            GameObject newText = _gameState.CurrentSign == SignType.X ? _oText : _xText;
            newText.SetActive(true);
            
            _gameState.OnCurrentSignChanged += ChangeColor;
            _gameState.OnCurrentSignChanged += ChangeText;
        }

        private void OnDestroy()
        {
            _gameState.OnCurrentSignChanged -= ChangeColor;
            _gameState.OnCurrentSignChanged -= ChangeText;
        }

        private void ChangeColor()
        {
            Color newColor = _gameState.CurrentSign == SignType.X ? _oColor : _xColor;
            
            _background.DOColor(newColor, _duration).SetEase(Ease.OutBack);
        }

        private void ChangeText()
        {
            var newText = _gameState.CurrentSign == SignType.X ? _oText : _xText;
            var oldText = _gameState.CurrentSign == SignType.X ? _xText : _oText;
            
            newText.SetActive(true);
            Animations.AnimateSign(newText.transform);
            oldText.SetActive(false);
        }
    }
}