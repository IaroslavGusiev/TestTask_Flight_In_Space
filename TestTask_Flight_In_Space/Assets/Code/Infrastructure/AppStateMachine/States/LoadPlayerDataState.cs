using Code.Services;
using System.Threading;
using Cysharp.Threading.Tasks;
using Code.Infrastructure.StateMachineBase;

namespace Code.Infrastructure.AppStateMachineScope
{
    public class LoadPlayerDataState : IState
    {
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly AppStateMachine _appStateMachine;

        public LoadPlayerDataState(PlayerDataProvider playerDataProvider, AppStateMachine appStateMachine)
        {
            _playerDataProvider = playerDataProvider;
            _appStateMachine = appStateMachine;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            _playerDataProvider.LoadPlayerData();
            await _appStateMachine.Enter<MainMenuState>(cancellationToken);
        }

        public async UniTask Exit() { }
    }
}