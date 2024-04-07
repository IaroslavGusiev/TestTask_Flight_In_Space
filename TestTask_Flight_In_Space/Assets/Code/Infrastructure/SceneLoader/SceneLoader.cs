using System;
using Code.StaticData;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public class SceneLoader : ISceneLoader
    {
        public UniTask LoadAsync(SceneName scene, Action onLoaded = null) =>
            LoadSceneAsync(scene.ToString(), onLoaded);

        public string GetNameOfCurrentScene() => 
            SceneManager.GetActiveScene().name;

        private async UniTask LoadSceneAsync(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                return;
            }
            
            await SceneManager
                .LoadSceneAsync(nextScene)
                .ToUniTask();
            
            onLoaded?.Invoke();
        }
    }
}