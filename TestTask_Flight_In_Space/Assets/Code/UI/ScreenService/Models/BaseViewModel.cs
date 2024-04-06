namespace Services.ScreenServiceSpace
{
    public abstract class BaseViewModel : IUiModel
    {
        protected IScreenService ScreenService;

        public virtual void InjectScreenService(IScreenService screenService) => 
            ScreenService = screenService;

        public virtual void OnShow() { }
        public virtual void Dispose() { }
        public virtual void OnClose() { }
    }
}