using System;
using Code.StaticData;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure
{
    public interface ISceneLoader
    {
        string GetNameOfCurrentScene();
        UniTask LoadAsync(SceneName scene, Action onLoaded = null);
    }
}