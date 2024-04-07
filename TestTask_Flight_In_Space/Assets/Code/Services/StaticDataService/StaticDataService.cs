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
        private List<GameSessionConfig> _gameSessionConfigs = new();

        public StaticDataService(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public async UniTask Initialize()
        {
            await LoadGameAssetConfig();
            await LoadGameSessionConfig();
        }

        public GameAssetConfig GetGameAssetConfig() => 
            _gameAssetConfigs.FirstOrDefault();

        public GameSessionConfig GetGameSessionConfig() => 
            _gameSessionConfigs.FirstOrDefault();

        private async UniTask LoadGameAssetConfig()
        { 
            GameAssetConfig[] configs = await GetConfigs<GameAssetConfig>();
            _gameAssetConfigs = configs.ToList();
        }

        private async UniTask LoadGameSessionConfig()
        {
            GameSessionConfig[] configs = await GetConfigs<GameSessionConfig>();
            _gameSessionConfigs = configs.ToList();
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