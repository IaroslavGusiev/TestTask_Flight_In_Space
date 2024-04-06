using UnityEngine;
using Code.StaticData;
using Code.Extensions;
using System.Collections;

namespace Code.Gameplay
{
    public class FlyModule
    {
        private readonly Transform _rootToMove;
        private readonly MonoBehaviour _coroutineLauncher;

        private Coroutine _flyAwaiter;
        private readonly float _minX;
        private readonly float _maxX;

        public FlyModule(Transform rootToMove, MonoBehaviour coroutineLauncher, ViewportBounds viewportBounds)
        {
            _rootToMove = rootToMove;
            _coroutineLauncher = coroutineLauncher;
            Vector2 viewportMinMax = viewportBounds.GetViewportMinMaxX();
            _minX = viewportMinMax.x;
            _maxX = viewportMinMax.y;
        }
        
        public void Cleanup()
        {
            _coroutineLauncher.TryToStopCoroutine(_flyAwaiter);
            _flyAwaiter = null;
        }

        public void Fly(TurnDirection turnDirection, float speed)
        {
           _coroutineLauncher.TryToStopCoroutine(_flyAwaiter);
           
           if (turnDirection == TurnDirection.StopTurn) 
               return;
           
           Vector3 direction = turnDirection == TurnDirection.LeftTurn ? Vector3.left : Vector3.right;
            _flyAwaiter = _coroutineLauncher.StartCoroutine(FlyCoroutine(direction, speed));
        }

        private IEnumerator FlyCoroutine(Vector3 direction, float speed)
        {
            while (true)
            {
                Vector3 movement = direction * speed * Time.deltaTime;
                Vector3 currentPos = _rootToMove.position;
                movement.x = Mathf.Clamp(movement.x, _minX - currentPos.x, _maxX - currentPos.x);
                currentPos += movement;
                _rootToMove.position = currentPos;
                yield return null;
            }
        }
    }
}