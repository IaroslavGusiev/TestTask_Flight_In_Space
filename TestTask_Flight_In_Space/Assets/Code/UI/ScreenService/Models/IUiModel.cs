using System;

namespace Services.ScreenServiceSpace
{
    public interface IUiModel : IDisposable
    {
        void InjectScreenService(IScreenService screenService);
        void OnShow();
        void OnClose();
    }
}