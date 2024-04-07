using UnityEngine;
using Code.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Code.Gameplay
{
    public class Asteroid : MonoBehaviour, IHittable
    {
        public bool CanFly { get; set; } = true;
        public bool IsFree { get; private set; } = true;

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private List<Sprite> _visualSprites;
        
        private const float OffsetFromFinishY = 1f;
        private Coroutine _flyAwaiter;

        private void OnDestroy() => 
            this.TryToStopCoroutine(_flyAwaiter);

        public void SetToGame(Vector3 inGamePosition, float finishYPos, float speed)
        {
            Enable(true);
            IsFree = false;
            SetRandomVisualSprite();
            transform.position = inGamePosition;
            _flyAwaiter = StartCoroutine(MoveAsteroidToFinishY(finishYPos, speed));
        }

        public void Enable(bool enable) => 
            gameObject.SetActive(enable);
    
        public void ResponseToHit()
        {
            this.TryToStopCoroutine(_flyAwaiter);
            gameObject.SetActive(false);
            Enable(false);
            IsFree = true;
        }
        
        private IEnumerator MoveAsteroidToFinishY(float finishYPos, float speed)
        {
            while (transform.position.y > finishYPos - OffsetFromFinishY) 
            {
                if (CanFly)
                    transform.position -= Vector3.up * speed * Time.deltaTime;
                yield return null;
            }
            ResponseToHit();
        }


        private void SetRandomVisualSprite() => 
            _spriteRenderer.sprite = _visualSprites.PickRandom();
    }
}