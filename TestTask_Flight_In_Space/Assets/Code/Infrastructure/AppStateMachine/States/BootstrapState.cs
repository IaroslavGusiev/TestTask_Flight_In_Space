using Code.Services;
using System.Threading;
using Cysharp.Threading.Tasks;
using Code.Services.StaticDataService;
using Code.Infrastructure.StateMachineBase;

namespace Code.Infrastructure.AppStateMachineScope
{
    public class BootstrapState : IState
    {
        private readonly IAssetProvider _assetProvider;
        private readonly AppStateMachine _appStateMachine;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(IAssetProvider assetProvider, AppStateMachine appStateMachine, IStaticDataService staticDataService)
        {
            _assetProvider = assetProvider;
            _appStateMachine = appStateMachine;
            _staticDataService = staticDataService;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            await _assetProvider.InitializeAsync();
            await _assetProvider.WarmupAssetsByLabel(AssetLabels.Configs);
            await _staticDataService.Initialize();
            await _appStateMachine.Enter<LoadPlayerDataState>(cancellationToken);
        }

        public async UniTask Exit() => 
            await _assetProvider.ReleaseAssetsByLabel(AssetLabels.Configs);
    }
}