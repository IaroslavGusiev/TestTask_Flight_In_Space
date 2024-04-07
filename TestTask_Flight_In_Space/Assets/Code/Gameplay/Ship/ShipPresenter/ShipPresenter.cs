using VContainer;
using UnityEngine;
using Code.StaticData;
using Gameplay.ShipSpace;

namespace Code.Gameplay
{
    public class ShipPresenter
    {
        private readonly ShipModel _model;
        private CollisionHitSystem _collisionHitSystem;
        private InputTurnWrapper _inputTurnWrapper;

        public ShipPresenter(ShipModel model) => 
            _model = model;

        [Inject]
        private void Construct(InputTurnWrapper inputTurnWrapper, CollisionHitSystem collisionHitSystem)
        {
            _collisionHitSystem = collisionHitSystem;
            _inputTurnWrapper = inputTurnWrapper;
            _inputTurnWrapper.OnTurnAction += HandleTurnAction;
        }
        
        public void Cleanup() =>
            _inputTurnWrapper.OnTurnAction -= HandleTurnAction;

        public void ResponseToCollision(Collider2D collidedObject)
        {
            if (collidedObject.TryGetComponent(out IHittable hittable))
            {
                hittable.ResponseToHit();
                _collisionHitSystem.RegisterHit(_model.GetCurrentWorldPosition());
            }
        }

        private void HandleTurnAction(TurnDirection turnDirection) => 
            _model.PerformFly(turnDirection);
    }
}