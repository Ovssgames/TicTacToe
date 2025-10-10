using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] GridUI gridUI;
        [SerializeField] BackgroundChanger backgroundChanger;
        
        
        public override void InstallBindings()
        {
            Container.Bind<GridSystem>().AsSingle();
            Container.Bind<GameState>().AsSingle().NonLazy();
            Container.Bind<GridUI>().FromInstance(gridUI).AsSingle();;
            Container.Bind<BackgroundChanger>().FromInstance(backgroundChanger).AsSingle();;
        }
    }
}
