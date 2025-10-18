using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] GridUI gridUI;
        [SerializeField] UIManager uiManager;
        
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GridSystem>().AsSingle();
            Container.Bind<GameState>().AsSingle().NonLazy();
            Container.Bind<CheckWinner>().AsSingle();
            Container.Bind<GridUI>().FromInstance(gridUI).AsSingle();;
            Container.Bind<UIManager>().FromInstance(uiManager).AsSingle();;
        }
    }
}
