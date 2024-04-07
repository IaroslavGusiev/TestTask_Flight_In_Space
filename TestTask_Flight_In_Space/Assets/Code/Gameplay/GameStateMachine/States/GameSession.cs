using System.Threading;
using Cysharp.Threading.Tasks;
using Code.Services.InputServiceSpace;
using Code.Infrastructure.StateMachineBase;

namespace Code.Gameplay
{
    public class GameSession : IState
    {
        private readonly IInputService _inputService;
        private readonly HittableSpawner _hittableSpawner;
        
        private CancellationTokenSource _cancellationTokenSource = new();

        public GameSession(HittableSpawner hittableSpawner, IInputService inputService)
        {
            _hittableSpawner = hittableSpawner;
            _inputService = inputService;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            _inputService.Enable(true);
            _cancellationTokenSource = new CancellationTokenSource();
            _hittableSpawner.UnpauseAllActiveHittables();
            await _hittableSpawner.StartSpawnHittables(_cancellationTokenSource.Token);
        }

        public async UniTask Exit()
        {
            _inputService.Enable(false);
            _cancellationTokenSource.Cancel();
            _hittableSpawner.PauseAllActiveHittables();
        }
    }
}