using UnityEngine;
using Code.Extensions;

namespace Code.Services
{
    public class SaveLoadService : ISaveLoadService
    {
        public void Save(string key, object objectToSave) => 
            PlayerPrefs.SetString(key, objectToSave.ToJson());

        public T Load<T>(string key)
        {
            string jsonString = PlayerPrefs.GetString(key);
            return !string.IsNullOrEmpty(jsonString) 
                ? JsonUtility.FromJson<T>(jsonString) 
                : default;
        }
    }
}