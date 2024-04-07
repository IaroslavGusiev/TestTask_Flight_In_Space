using System.Threading;
using Cysharp.Threading.Tasks;
using Services.ScreenServiceSpace;
using Code.Infrastructure.StateMachineBase;
using Code.Infrastructure.AppStateMachineScope;

namespace Code.MainMenu.States
{
    public class Init : IState
    {
        private readonly IScreenService _screenService;
        private readonly AppStateMachine _appStateMachine;

        public Init(IScreenService screenService, AppStateMachine appStateMachine)
        {
            _screenService = screenService;
            _appStateMachine = appStateMachine;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            _screenService.Init();
            _screenService.BindModel(new MainScreenModel(_appStateMachine, cancellationToken));
            _screenService.Show<MainScreenModel>();
        }

        public async UniTask Exit() { }
    }
}