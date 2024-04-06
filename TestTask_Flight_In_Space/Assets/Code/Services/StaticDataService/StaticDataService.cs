using System.Linq;
using Code.StaticData;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

namespace Code.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;
        private List<GameAssetConfig> _gameAssetConfigs = new();

        public StaticDataService(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public async UniTask Initialize()
        {
            await LoadGameAssetConfig();
        }

        public GameAssetConfig GetGameAssetConfig() => 
            _gameAssetConfigs.FirstOrDefault();

        private async UniTask LoadGameAssetConfig()
        { 
            GameAssetConfig[] configs = await GetConfigs<GameAssetConfig>();
            _gameAssetConfigs = configs.ToList();
        }

        private async UniTask<T[]> GetConfigs<T>() where T : class
        {
            List<string> keys = await GetConfigsKeys<T>();
            T[] loadedConfigs = await _assetProvider.LoadAll<T>(keys);
            return loadedConfigs;
        }

        private async UniTask<List<string>> GetConfigsKeys<T>() =>
            await _assetProvider.FetchAssetKeysByLabel<T>(AssetLabels.Configs);
    }
}