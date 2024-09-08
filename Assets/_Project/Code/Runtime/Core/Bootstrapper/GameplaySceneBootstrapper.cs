using _Project.Code.Runtime.Config;
using _Project.Code.Runtime.Core.AssetManagement;
using _Project.Code.Runtime.Core.Util;
using _Project.Code.Runtime.Gameplay.Stats;
using _Project.Code.Runtime.Gameplay.Unit.Facade;
using UnityEngine;
using Zenject;

namespace _Project.Code.Runtime.Core.Bootstrapper
{
    public class GameplaySceneBootstrapper : IInitializable
    {
        [Inject] private IInstantiator _container;
        [Inject] private IAssetProvider _assetProvider;
        [Inject] private ConfigProvider _configProvider;

        public void Initialize()
        {
            _configProvider.LoadSingle<PlayerStats>(Constants.AssetPath.PlayerStats);
            
            var levelConfig = _configProvider.GetSingleImmediately<LevelConfig>(Constants.AssetPath.LevelConfig);
            var player = _assetProvider.Load<PlayerFacade>(Constants.AssetPath.PlayerPrefab);
            
            _container.InstantiatePrefab(player, levelConfig.PlayerSpawnPoint, Quaternion.identity, null);
        }
    }
}