namespace Services.ScreenServiceSpace
{
    public interface IScreenService
    {
        void Init(IScreensProvider screensProvider);
        void Show<TModel>() where TModel : BaseViewModel;
        void Show<TModel>(TModel model) where TModel : BaseViewModel;
        void Close<TModel>() where TModel : BaseViewModel;
        void BindModel<TModel>(TModel model) where TModel : BaseViewModel;
    }
}