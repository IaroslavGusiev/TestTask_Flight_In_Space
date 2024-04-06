using System;

namespace Code.MainMenu
{
    public struct PopUpButtonBind
    {
        public string Text { get; set; }
        public Action OnClick { get; set; }

        public PopUpButtonBind(string text, Action onClick)
        {
            Text = text;
            OnClick = onClick;
        }
    }
}