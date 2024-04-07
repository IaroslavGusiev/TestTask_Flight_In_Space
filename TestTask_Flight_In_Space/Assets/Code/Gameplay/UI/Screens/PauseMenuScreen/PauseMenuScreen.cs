using UnityEngine;
using UnityEngine.UI;
using Code.Extensions;
using Services.ScreenServiceSpace;

namespace Code.Gameplay.UI
{
    public class PauseMenuScreen : AbstractScreen<PauseMenuModel>
    {
        [SerializeField] protected Button _pauseButton;
        
        protected override void OnBind(PauseMenuModel model) => 
            _pauseButton.Add(model.ShowPausePopUp);
    }
}