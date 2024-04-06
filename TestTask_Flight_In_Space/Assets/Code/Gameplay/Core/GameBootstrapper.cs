using VContainer;
using System.Threading;
using Code.Infrastructure;
using Cysharp.Threading.Tasks;
using Code.Infrastructure.StateMachineBase;

namespace Code.Gameplay
{ 
    public class GameBootstrapper : ScopeBootstrapper<GameStateMachine>
    {
        public GameBootstrapper(GameStateMachine stateMachine, StateFactory stateFactory) : base(stateMachine, stateFactory) { }

        protected override async UniTask StartLogic(CancellationToken token)
        {
            StateMachine.RegisterState(StateFactory.Create<PrepareLevelState>(Lifetime.Scoped));
            await StateMachine.Enter<PrepareLevelState>(token);
        }
    }
}