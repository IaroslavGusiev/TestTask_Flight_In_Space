using UnityEngine;
using UnityEngine.UI;
using Code.Extensions;
using Services.ScreenServiceSpace;

namespace Code.MainMenu
{
    public class MainMenuScreen : AbstractScreen<MainScreenModel>
    {
        [SerializeField] protected Button _playButton;
        [SerializeField] protected Button _quitButton;
        
        protected override void OnBind(MainScreenModel model)
        {
            _playButton.Add(model.ShowPlayPopUp);
            _quitButton.Add(model.ShowExitPopUp);
        }
    }
}