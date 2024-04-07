using System.Threading;
using Code.Gameplay.UI;
using Code.Infrastructure;
using Cysharp.Threading.Tasks;
using Services.ScreenServiceSpace;
using Code.Infrastructure.StateMachineBase;
using Code.Infrastructure.AppStateMachineScope;

namespace Code.Gameplay
{
    public class PrepareLevelState : IState
    {
        private readonly IGameFactory _gameFactory;
        private readonly IScreenService _screenService;
        private readonly IAppStateMachine _appStateMachine;
        private readonly GameStateMachine _gameStateMachine;
        private readonly ICollisionHitSystem _collisionHitSystem;

        public PrepareLevelState(IGameFactory gameFactory, GameStateMachine gameStateMachine, IScreenService screenService, IAppStateMachine appStateMachine, ICollisionHitSystem collisionHitSystem)
        {
            _gameFactory = gameFactory;
            _screenService = screenService;
            _appStateMachine = appStateMachine;
            _gameStateMachine = gameStateMachine;
            _collisionHitSystem = collisionHitSystem;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            LevelBehaviour level = await _gameFactory.CreateBattlefieldBehaviour();
            await _gameFactory.CreateShipBehaviour(level.ShipSpawnPosition.position);
            PrepareAndShowRequiredScreens(cancellationToken);
            await _gameStateMachine.Enter<GameSession>(cancellationToken);
        }

        private void PrepareAndShowRequiredScreens(CancellationToken cancellationToken)
        {
            _screenService.Init();
            _screenService.BindModel(new PauseMenuModel(_appStateMachine, _gameStateMachine, cancellationToken));
            _screenService.Show<PauseMenuModel>();
            _screenService.BindModel(new CollisionHitModel(_collisionHitSystem));
            _screenService.Show<CollisionHitModel>();
        }

        public async UniTask Exit() { }
    }
}