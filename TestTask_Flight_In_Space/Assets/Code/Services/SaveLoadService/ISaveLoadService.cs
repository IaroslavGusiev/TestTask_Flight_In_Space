namespace Code.Services
{
    public interface ISaveLoadService
    {
        void Save(string key, object objectToSave);
        T Load<T>(string key);
    }
}