using UnityEngine;
using Code.Extensions;
using System.Collections;
using Random = UnityEngine.Random;

namespace Code.Gameplay
{
    public class SpriteOutline : MonoBehaviour
    {
        private static readonly int Outline = Shader.PropertyToID("_Outline");
        private static readonly int OutlineSize = Shader.PropertyToID("_OutlineSize");
        private static readonly int OutlineColor = Shader.PropertyToID("_OutlineColor");
        
        [SerializeField] private Color[] _colors;
        [SerializeField] private float _changeInterval;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private MaterialPropertyBlock _materialPropertyBlock;
        private Coroutine _outlineAwaiter;
        
        private void Awake() => 
            _materialPropertyBlock = new MaterialPropertyBlock();

        private void Start() => 
            _outlineAwaiter = StartCoroutine(ColorChangeCoroutine());

        private void OnDestroy() => 
            this.TryToStopCoroutine(_outlineAwaiter);

        private IEnumerator ColorChangeCoroutine()
        {
            while (true)
            {
                foreach (Color color in _colors)
                {
                    _spriteRenderer.GetPropertyBlock(_materialPropertyBlock);
                    _spriteRenderer.GetPropertyBlock(_materialPropertyBlock);
                    _materialPropertyBlock.SetFloat(Outline, 1f);
                    _materialPropertyBlock.SetColor(OutlineColor, color);
                    _materialPropertyBlock.SetFloat(OutlineSize, GetRandomOutlineSize());
                    _spriteRenderer.SetPropertyBlock(_materialPropertyBlock);
                    yield return new WaitForSeconds(_changeInterval);
                }
            }
        }

        private float GetRandomOutlineSize() => 
            Random.Range(1f, 2f);
    }
}