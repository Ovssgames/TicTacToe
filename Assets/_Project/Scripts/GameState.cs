using System;

namespace _Project.Scripts
{
    public class GameState
    {
        public event Action OnCurrentSignChanged; 
        
        public SignType CurrentSign { get; private set; }

        public void ChangeCurrentSign()
        {
            CurrentSign = CurrentSign == SignType.X ? SignType.O : SignType.X;
            OnCurrentSignChanged?.Invoke();
        }
    }
}