using System;
using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    public class GameState
    {
        public event Action OnCurrentSignChanged;
        public event Action OnGameOver;

        public SignType CurrentSign { get; private set; } = SignType.X;
        public string Winner { get; private set; }

        public void NextTurn()
        {
            ChangeCurrentSign();
            OnCurrentSignChanged?.Invoke();
        }

        private void ChangeCurrentSign()
        {
            CurrentSign = CurrentSign == SignType.X ? SignType.O : SignType.X;
        }

        public void EndGame(string winner)
        {
            ChangeCurrentSign();
            Winner = winner;
            Debug.Log($"Game Over    {winner}");
            OnGameOver?.Invoke();
        }
    }
}