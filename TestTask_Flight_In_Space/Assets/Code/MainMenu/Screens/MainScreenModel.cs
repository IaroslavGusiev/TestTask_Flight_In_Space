using System.Threading;
using Cysharp.Threading.Tasks;
using Services.ScreenServiceSpace;
using Code.Infrastructure.AppStateMachineScope;

namespace Code.MainMenu
{
    public class MainScreenModel : BasePersistentModel<MainScreenModel>
    {
        private const string YesTextString = "Yes";
        private const string NoTextString = "No";

        private readonly IAppStateMachine _appStateMachine;
        private readonly CancellationToken _cancellationToken;

        public MainScreenModel(IAppStateMachine appStateMachine, CancellationToken cancellationToken)
        {
            _appStateMachine = appStateMachine;
            _cancellationToken = cancellationToken;
        }

        public void ShowPlayPopUp()
        {
            var positiveButtonBind = new PopUpButtonBind(YesTextString, EnterGameLoopState);
            var negativeButtonBind = new PopUpButtonBind(NoTextString, null);

            ScreenService.Show(new PopUpModel("Start new game", new[] { positiveButtonBind, negativeButtonBind }, null));
        }

        public void ShowExitPopUp()
        {
            var positiveButtonBind = new PopUpButtonBind(YesTextString, EnterCloseGameState);
            var negativeButtonBind = new PopUpButtonBind(NoTextString, null);
            
            ScreenService.Show(new PopUpModel("Want to exit?", new[] { positiveButtonBind, negativeButtonBind }, null));
        }

        private void EnterGameLoopState() => 
            _appStateMachine
                .Enter<GameLoopState>(_cancellationToken)
                .Forget();

        private void EnterCloseGameState() => 
            _appStateMachine
                .Enter<CloseGameState>(_cancellationToken)
                .Forget();
    }
}