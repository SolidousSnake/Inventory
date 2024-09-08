using _Project.Code.Runtime.Core.AssetManagement;
using _Project.Code.Runtime.Core.SceneManagement;
using _Project.Code.Runtime.Services.Input;
using _Project.Code.Runtime.Services.SaveLoad;
using UnityEngine;
using Zenject;

namespace _Project.Code.Runtime.Core.Installer
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private InputService _inputService;
        
        public override void InstallBindings()
        {
            BindProviders();
            BindServices();
        }

        private void BindServices()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ISaveLoadService>().To<JsonSaveLoadService>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputService>().FromComponentInNewPrefab(_inputService).AsSingle();
        }

        private void BindProviders()
        {
            Container.Bind<ConfigProvider>().AsSingle();
            Container.Bind<IAssetProvider>().To<ResourcesAssetProvider>().AsSingle();
        }
    }
}