using System.Threading;
using Gameplay.ShipSpace;
using Code.Infrastructure;
using Cysharp.Threading.Tasks;
using Code.Infrastructure.StateMachineBase;

namespace Code.Gameplay
{
    public class PrepareLevelState : IState
    {
        private readonly IGameFactory _gameFactory;

        public PrepareLevelState(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            LevelBehaviour level = await _gameFactory.CreateBattlefieldBehaviour();
            ShipBehaviour ship = await _gameFactory.CreateShipBehaviour(level.ShipSpawnPosition.position);
        }

        public async UniTask Exit()
        {
            
        }
    }
}