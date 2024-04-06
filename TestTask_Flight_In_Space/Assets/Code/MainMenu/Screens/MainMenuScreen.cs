using UnityEngine;
using UnityEngine.UI;
using Services.ScreenServiceSpace;

namespace Code.MainMenu
{
    public class MainMenuScreen : AbstractScreen<MainScreenModel>
    {
        [SerializeField] protected Button _playButton;
        [SerializeField] protected Button _quitButton;
        
        protected override void OnBind(MainScreenModel model)
        {
            _playButton.onClick.AddListener(model.ShowPlayPopUp);
            _quitButton.onClick.AddListener(model.ShowExitPopUp);
        }
    }
}