using Code.MainMenu;
using System.Threading;
using Cysharp.Threading.Tasks;
using Services.ScreenServiceSpace;
using Code.Infrastructure.AppStateMachineScope;

namespace Code.Gameplay.UI
{
    public class PauseMenuModel : BasePersistentModel<PauseMenuModel>
    {
        private const string YesTextString = "Yes";
        private const string NoTextString = "No";

        private readonly IAppStateMachine _appStateMachine;
        private readonly GameStateMachine _gameStateMachine;
        private readonly CancellationToken _cancellationToken;

        public PauseMenuModel(IAppStateMachine appStateMachine, GameStateMachine gameStateMachine, CancellationToken cancellationToken)
        {
            _appStateMachine = appStateMachine;
            _gameStateMachine = gameStateMachine;
            _cancellationToken = cancellationToken;
        }

        public void ShowPausePopUp()
        {
            _gameStateMachine.Enter<PauseState>(_cancellationToken).Forget();
            
            var positiveButtonBind = new PopUpButtonBind(YesTextString, EnterCloseGameState);
            var negativeButtonBind = new PopUpButtonBind(NoTextString, SwitchToGameSessionState);

            ScreenService.Show(new PopUpModel("Exit From Game", new[] { positiveButtonBind, negativeButtonBind }, SwitchToGameSessionState));
        }

        private void EnterCloseGameState() => 
            _appStateMachine
                .Enter<CloseGameState>(_cancellationToken)
                .Forget();

        private void SwitchToGameSessionState() => 
            _gameStateMachine
                .Enter<GameSession>(_cancellationToken)
                .Forget();
    }
}