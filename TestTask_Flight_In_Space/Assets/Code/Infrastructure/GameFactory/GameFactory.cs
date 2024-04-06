using VContainer;
using UnityEngine;
using Code.Gameplay;
using Code.Services;
using Code.StaticData;
using VContainer.Unity;
using Gameplay.ShipSpace;
using Cysharp.Threading.Tasks;
using Code.Services.StaticDataService;

namespace Code.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly GameAssetConfig _assetConfig;
        private readonly IAssetProvider _assetProvider;
        private readonly IObjectResolver _objectResolver;
        private readonly InputTurnWrapper _inputTurnWrapper;

        public GameFactory(IObjectResolver objectResolver, IAssetProvider assetProvider, IStaticDataService staticDataService, InputTurnWrapper inputTurnWrapper)
        {
            _assetProvider = assetProvider;
            _objectResolver = objectResolver;
            _inputTurnWrapper = inputTurnWrapper;
            _assetConfig = staticDataService.GetGameAssetConfig();
        }

        public async UniTask<LevelBehaviour> CreateBattlefieldBehaviour()
        {
            var prefab = await _assetProvider.LoadAndGetComponent<LevelBehaviour>(_assetConfig.LevelPrefabAddress);
            return _objectResolver.Instantiate(prefab, null);
        }

        public async UniTask<Asteroid> CreateAsteroid(Transform container)
        {
            var prefab = await _assetProvider.LoadAndGetComponent<Asteroid>(_assetConfig.AsteroidPrefabAddress);
            return _objectResolver.Instantiate(prefab, container);
        }
        
        public async UniTask<ShipBehaviour> CreateShipBehaviour(Vector3 at)
        {
            var prefab = await _assetProvider.LoadAndGetComponent<ShipBehaviour>(_assetConfig.SpaceShipPrefabAddress);
            ShipBehaviour shipBehaviour = _objectResolver.Instantiate(prefab, at, Quaternion.identity);
            CreateShipEntity(shipBehaviour);
            return shipBehaviour;
        }

        private void CreateShipEntity(ShipBehaviour shipBehaviour)
        {
            var shipModel = new ShipModel(shipBehaviour);
            var shipPresenter = new ShipPresenter(shipModel, _inputTurnWrapper);
            shipBehaviour.SetPresenter(shipPresenter);
        }
    }
}