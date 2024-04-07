using VContainer;
using System.Threading;
using Code.Infrastructure;
using Cysharp.Threading.Tasks;
using Code.Infrastructure.AnalyticsSpace;
using Code.Infrastructure.StateMachineBase;

namespace Code.Gameplay
{ 
    public class GameBootstrapper : ScopeBootstrapper<GameStateMachine>
    {
        public GameBootstrapper(GameStateMachine stateMachine, StateFactory stateFactory, IAnalyticsModule analyticsModule, ISceneLoader sceneLoader) : base(stateMachine, stateFactory, analyticsModule, sceneLoader) { }

        protected override async UniTask StartLogic(CancellationToken token)
        {
            StateMachine.RegisterState(StateFactory.Create<PrepareLevelState>(Lifetime.Scoped));
            StateMachine.RegisterState(StateFactory.Create<GameSession>(Lifetime.Scoped));
            StateMachine.RegisterState(StateFactory.Create<PauseState>(Lifetime.Scoped));
            await StateMachine.Enter<PrepareLevelState>(token);
        }
    }
}