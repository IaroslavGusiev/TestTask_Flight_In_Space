namespace Services.ScreenServiceSpace
{
    public abstract class BaseOneShowModel<TModel> : BaseViewModel where TModel : BaseViewModel
    {
        public void Close()
        {
            ScreenService.Close<TModel>();
        }
    }
}