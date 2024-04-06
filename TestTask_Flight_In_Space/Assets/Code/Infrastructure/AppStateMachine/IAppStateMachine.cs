using System.Threading;
using Cysharp.Threading.Tasks;
using Code.Infrastructure.StateMachineBase;

namespace Code.Infrastructure.AppStateMachineScope
{
    public interface IAppStateMachine
    {
        UniTask Enter<TState>(CancellationToken cancellationToken) where TState : class, IState;
    }
}