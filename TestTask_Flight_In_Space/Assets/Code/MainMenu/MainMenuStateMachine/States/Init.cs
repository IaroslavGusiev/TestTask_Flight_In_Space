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
        private readonly IScreensProvider _screensProvider;
        private readonly AppStateMachine _appStateMachine;

        public Init(IScreenService screenService, IScreensProvider screensProvider, AppStateMachine appStateMachine)
        {
            _screenService = screenService;
            _screensProvider = screensProvider;
            _appStateMachine = appStateMachine;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            _screenService.Init(_screensProvider);
            _screenService.BindModel(new MainScreenModel(_appStateMachine, cancellationToken));
            _screenService.Show<MainScreenModel>();
        }

        public async UniTask Exit()
        {
            
        }
    }
}