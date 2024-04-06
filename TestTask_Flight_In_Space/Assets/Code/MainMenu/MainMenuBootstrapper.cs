using VContainer;
using System.Threading;
using Code.Infrastructure;
using Code.MainMenu.States;
using Cysharp.Threading.Tasks;
using Code.Infrastructure.StateMachineBase;

namespace Code.MainMenu
{
    public class MainMenuBootstrapper : ScopeBootstrapper<MainMenuStateMachine>
    {
        public MainMenuBootstrapper(MainMenuStateMachine stateMachine, StateFactory stateFactory) : base(stateMachine, stateFactory) { }

        protected override async UniTask StartLogic(CancellationToken token)
        {
            StateMachine.RegisterState(StateFactory.Create<Init>(Lifetime.Scoped));
            await StateMachine.Enter<Init>(token);
        }
    }
}