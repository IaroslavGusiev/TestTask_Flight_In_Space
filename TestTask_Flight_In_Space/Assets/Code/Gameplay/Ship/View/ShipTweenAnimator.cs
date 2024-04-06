using DG.Tweening;
using UnityEngine;
using Code.Extensions;
using Code.StaticData;

namespace Code.Gameplay
{
    public class ShipTweenAnimator : MonoBehaviour
    {
        [SerializeField] private Transform _flame;
        [SerializeField] private Transform _animationRoot;
        
        private readonly Vector3 _rightRotationVector = new Vector3(0f, 0f, -20f);
        private readonly Vector3 _leftRotationVector = new Vector3(0f, 0f, 20f);
        private Tween _rotationTween;

        private void Start() => 
            AnimateFlame();

        public void AnimateTurn(TurnDirection turnDirection)
        {
            switch (turnDirection)
            {
                case TurnDirection.StopTurn:
                    RotateAnimationRoot(Vector3.zero);
                    break;
                case TurnDirection.LeftTurn:
                    RotateAnimationRoot(_leftRotationVector);
                    break;
                case TurnDirection.RightTurn:
                    RotateAnimationRoot(_rightRotationVector);
                    break;
            }
        }

        private void AnimateFlame()
        {
            _flame
                .DOScaleY(1.1f, 0.1f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetLink(gameObject);
        }

        private void RotateAnimationRoot(Vector3 vector)
        {
            _rotationTween.KillIfValid();
            
            _animationRoot
                .DORotate(vector, 0.5f)
                .SetLink(gameObject);
        }
    }
}   