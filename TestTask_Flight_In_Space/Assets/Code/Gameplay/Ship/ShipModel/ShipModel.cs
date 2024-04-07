using UnityEngine;
using Code.Gameplay;
using Code.StaticData;

namespace Gameplay.ShipSpace
{
    public class ShipModel
    {
        private readonly ShipBehaviour _shipBehaviour;
        private readonly float _speed;

        public ShipModel(ShipBehaviour shipBehaviour, float speed)
        {
            _shipBehaviour = shipBehaviour;
            _speed = speed;
        }

        public void PerformFly(TurnDirection turnDirection) => 
            _shipBehaviour.PerformFly(turnDirection, _speed);

        public Vector3 GetCurrentWorldPosition() => 
            _shipBehaviour.transform.position;
    }
}