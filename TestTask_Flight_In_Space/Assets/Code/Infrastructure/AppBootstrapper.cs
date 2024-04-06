using VContainer;
using System.Threading;
using Cysharp.Threading.Tasks;
using Code.Infrastructure.StateMachineBase;

namespace Code.Infrastructure.AppStateMachineScope
{
    public class AppBootstrapper : ScopeBootstrapper<AppStateMachine>
    {
        public AppBootstrapper(AppStateMachine stateMachine, StateFactory stateFactory) : base(stateMachine, stateFactory) { }
    
        protected override async UniTask StartLogic(CancellationToken token)
        {
            StateMachine.RegisterState(StateFactory.Create<BootstrapState>(Lifetime.Scoped));
            StateMachine.RegisterState(StateFactory.Create<LoadPlayerDataState>(Lifetime.Scoped));
            StateMachine.RegisterState(StateFactory.Create<MainMenuState>(Lifetime.Scoped));
            StateMachine.RegisterState(StateFactory.Create<GameLoopState>(Lifetime.Scoped));
            StateMachine.RegisterState(StateFactory.Create<CloseGameState>(Lifetime.Scoped));
            
            await StateMachine.Enter<BootstrapState>(token);
        }
    }
}