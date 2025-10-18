using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private Button  _button;
        
        private void Start()
        {         
            _button.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        }
    }
}