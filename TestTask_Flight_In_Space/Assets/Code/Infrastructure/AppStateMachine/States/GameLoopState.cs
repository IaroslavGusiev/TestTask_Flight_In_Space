using Code.UI;
using Code.Services;
using Code.StaticData;
using System.Threading;
using Cysharp.Threading.Tasks;
using Code.Infrastructure.StateMachineBase;

namespace Code.Infrastructure.AppStateMachineScope
{
    public class GameLoopState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IAssetProvider _assetProvider;
        private readonly ILoadingCurtain _loadingCurtain;

        public GameLoopState(ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain, IAssetProvider assetProvider)
        {
            _sceneLoader = sceneLoader;
            _assetProvider = assetProvider;
            _loadingCurtain = loadingCurtain;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            _loadingCurtain.Show();
            await _assetProvider.WarmupAssetsByLabel(AssetLabels.GameAssets);
            await _sceneLoader.LoadAsync(SceneName.Game, () => _loadingCurtain.Hide());
        }

        public async UniTask Exit() => 
            await _assetProvider.ReleaseAssetsByLabel(AssetLabels.GameAssets);
    }
}