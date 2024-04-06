using Code.Gameplay;
using Code.StaticData;

namespace Gameplay.ShipSpace
{
    public class ShipModel
    {
        public float Speed = 1.5f;
        private readonly ShipBehaviour _shipBehaviour;

        public ShipModel(ShipBehaviour shipBehaviour)
        {
            _shipBehaviour = shipBehaviour;
        }

        public void PerformFly(TurnDirection turnDirection)
        {
            _shipBehaviour.PerformFly(turnDirection, Speed);
        }
    }
}