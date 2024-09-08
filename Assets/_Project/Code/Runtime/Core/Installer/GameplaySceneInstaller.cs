using _Project.Code.Runtime.Core.Bootstrapper;
using _Project.Code.Runtime.UI.Bar;
using _Project.Code.Runtime.UI.View;
using UnityEngine;
using Zenject;

namespace _Project.Code.Runtime.Core.Installer
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private StatsView _statsView;
        [SerializeField] private HealthBar _healthBar;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_inventoryView);
            Container.BindInstance(_statsView);
            Container.BindInstance(_healthBar);
            
            Container.BindInterfacesAndSelfTo<GameplaySceneBootstrapper>().AsSingle().NonLazy();
        }
    }
}