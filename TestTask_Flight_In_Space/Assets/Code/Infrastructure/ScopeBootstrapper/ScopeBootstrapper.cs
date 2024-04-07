using System.Threading;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using Code.Infrastructure.AnalyticsSpace;
using Code.Infrastructure.StateMachineBase;

namespace Code.Infrastructure
{
    public abstract class ScopeBootstrapper<T> : IAsyncStartable where T : StateMachine
    {
        protected readonly T StateMachine;
        protected readonly StateFactory StateFactory;

        private readonly ISceneLoader _sceneLoader;
        private readonly IAnalyticsModule _analyticsModule;

        protected ScopeBootstrapper(T stateMachine, StateFactory stateFactory, IAnalyticsModule analyticsModule, ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            StateMachine = stateMachine;
            StateFactory = stateFactory;
            _analyticsModule = analyticsModule;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            _analyticsModule.LogThatSceneWasLoaded(_sceneLoader.GetNameOfCurrentScene());
            await StartLogic(cancellation);
        }

        protected abstract UniTask StartLogic(CancellationToken token);
    }
}