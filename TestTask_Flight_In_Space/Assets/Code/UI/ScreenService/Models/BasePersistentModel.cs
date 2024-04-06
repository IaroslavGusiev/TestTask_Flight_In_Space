namespace Services.ScreenServiceSpace
{
    public class BasePersistentModel<TModel> : BaseViewModel where TModel : BaseViewModel
    {
        public void Close()
        {
            ScreenService.Close<TModel>();
        }
    }
}