using UnityEngine;
using Code.StaticData;
using Gameplay.ShipSpace;

namespace Code.Gameplay
{
    public class ShipPresenter
    {
        private readonly ShipModel _model;
        private readonly InputTurnWrapper _inputTurnWrapper;

        public ShipPresenter(ShipModel model, InputTurnWrapper inputTurnWrapper)
        {
            _model = model;
            _inputTurnWrapper = inputTurnWrapper;
            _inputTurnWrapper.OnTurnAction += HandleTurnAction;
        }

        private void HandleTurnAction(TurnDirection turnDirection) => 
            _model.PerformFly(turnDirection);

        public void ResponseToCollision(Collider2D collidedObject)
        {
            if (collidedObject.TryGetComponent(out IHittable hittable))
            {
                Debug.Log($"<color=yellow> {hittable} </color>");
                hittable.ResponseToHit();
            }
        }
    }
}