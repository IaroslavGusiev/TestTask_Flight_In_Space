using UnityEngine;

namespace Code.Gameplay
{
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField] private Transform _backgroundRoot;
        [SerializeField] private Transform _background1;
        [SerializeField] private Transform _background2;
        [SerializeField] private float _scrollSpeed;
        private const float FixedHeight = 20f;

        public void LaunchScroll()
        {
            float movementAmount = _scrollSpeed * Time.deltaTime;
            _backgroundRoot.position += Vector3.down * movementAmount;
            
            if (_background1.position.y <= -FixedHeight)
            {
                _background1.position += Vector3.up * FixedHeight * 2;
                SwitchBackgrounds();
            }
            else if (_background2.position.y <= -FixedHeight)
            {
                _background2.position += Vector3.up * FixedHeight * 2;
                SwitchBackgrounds();
            }
        }

        private void SwitchBackgrounds() => 
            (_background1, _background2) = (_background2, _background1);
    }
}