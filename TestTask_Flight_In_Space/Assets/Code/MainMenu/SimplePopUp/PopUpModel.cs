using System;
using Services.ScreenServiceSpace;

namespace Code.MainMenu
{
    public class PopUpModel : BaseOneShowModel<PopUpModel>
    {
        private readonly Action _onCloseAction;
        
        public PopUpModel(string message, PopUpButtonBind[] binds, Action onCloseAction)
        {
            Binds = binds;
            MessageText = message;
            _onCloseAction = onCloseAction;
        }

        public PopUpButtonBind[] Binds { get; }
        public string MessageText { get; }

        public override void OnClose() => 
            _onCloseAction?.Invoke();
    }
}