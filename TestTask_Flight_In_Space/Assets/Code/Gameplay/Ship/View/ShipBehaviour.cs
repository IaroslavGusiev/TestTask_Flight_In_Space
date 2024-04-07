using VContainer;
using UnityEngine;
using Code.StaticData;

namespace Code.Gameplay
{
    public class ShipBehaviour : MonoBehaviour
    {
        [SerializeField] private ShipTweenAnimator _shipTweenAnimator;
        [SerializeField] private TriggerObserver _triggerObserver;

        private FlyModule _flyModule;
        private ShipPresenter _shipPresenter;

        [Inject]
        private void Construct(ViewportBounds viewportBounds) => 
            _flyModule = new FlyModule(transform, this, viewportBounds);

        private void OnEnable() => 
            _triggerObserver.OnTriggerEnter += HandleTriggerEnter;

        private void OnDisable() => 
            _triggerObserver.OnTriggerEnter -= HandleTriggerEnter;

        private void OnDestroy()
        {
            _flyModule.Cleanup();
            _shipPresenter.Cleanup();
        }

        public void SetPresenter(ShipPresenter shipPresenter) => 
            _shipPresenter = shipPresenter;

        public void PerformFly(TurnDirection turnDirection, float speed)
        {
            _shipTweenAnimator.AnimateTurn(turnDirection);
            _flyModule.Fly(turnDirection, speed);
        }

        private void HandleTriggerEnter(Collider2D collidedObject) => 
            _shipPresenter.ResponseToCollision(collidedObject);
    }
}