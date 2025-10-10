using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts
{
    public class BackgroundChanger :  MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private float _duration = 0.5f;
        [Space]
        [SerializeField] Color _Xcolor;
        [SerializeField] Color _Ocolor;

        private GameState _gameState;
        
        
        [Inject]
        private void Init(GameState gameState)
        {
            _gameState = gameState;
        }

        private void Start()
        {
            _background.color = _gameState.CurrentSign == SignType.X ? _Ocolor : _Xcolor;
            
            _gameState.OnCurrentSignChanged += ChangeColor;
        }

        private void OnDestroy()
        {
            _gameState.OnCurrentSignChanged -= ChangeColor;
        }

        private void ChangeColor()
        {
            Color newColor = _gameState.CurrentSign == SignType.X ? _Ocolor : _Xcolor;
            
            _background.DOColor(newColor, _duration).SetEase(Ease.OutBack);
        }
    }
}