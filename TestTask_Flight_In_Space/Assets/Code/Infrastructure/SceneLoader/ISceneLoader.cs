using System;
using Code.StaticData;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure
{
    public interface ISceneLoader
    {
        UniTask LoadAsync(SceneName scene, Action onLoaded = null);
    }
}