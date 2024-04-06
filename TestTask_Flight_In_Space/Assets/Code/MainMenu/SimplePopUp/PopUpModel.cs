using Services.ScreenServiceSpace;

namespace Code.MainMenu
{
    public class PopUpModel : BaseOneShowModel<PopUpModel>
    {
        public PopUpModel(string message, PopUpButtonBind[] binds)
        {
            MessageText = message;
            Binds = binds;
        }

        public PopUpButtonBind[] Binds { get; }
        public string MessageText { get; }
    }
}