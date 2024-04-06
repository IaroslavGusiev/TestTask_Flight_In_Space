using UnityEngine;
using VContainer.Unity;

namespace Code.Gameplay
{
    public class ViewportBounds : IInitializable
    {
        private Camera _renderCamera;
        private Rect _bounds;
        
        public void Initialize()
        {
            _renderCamera = Camera.main;
            _bounds = GetViewportBounds();
        }

        public Vector2 GetViewportMinMaxX()
        {
            Vector3 lowerLeft = _renderCamera.ViewportToWorldPoint(new Vector3(_bounds.xMin, _bounds.yMin, 0f));
            Vector3 upperRight = _renderCamera.ViewportToWorldPoint(new Vector3(_bounds.xMax, _bounds.yMax, 0f));
            return new Vector2(lowerLeft.x, upperRight.x);
        }

        public Vector3 GetRandomTopPoint()
        {
            var randomPoint = new Vector3(Random.Range(_bounds.xMin, _bounds.xMax), _bounds.yMax, 0f);
            Vector3 worldPos  =_renderCamera.ViewportToWorldPoint(randomPoint);
            worldPos.z = 0;
            return worldPos;
        }

        public float GetYBottomPoint()
        {
            float bottomY = _renderCamera.transform.position.y - _renderCamera.orthographicSize;
            return bottomY;
        }

        private Rect GetViewportBounds()
        {
            var viewportBounds = new Rect(0f, 0f, 1f, 1f);
            float screenHeight =_renderCamera.orthographicSize * 2;
            viewportBounds.yMin = screenHeight / 2f;
            viewportBounds.xMin = 0f;
            viewportBounds.xMax = 1f;
            viewportBounds.yMax = 1f;
            return viewportBounds;
        }
    }
}