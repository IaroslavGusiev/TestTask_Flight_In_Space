using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Services.InputServiceSpace
{
    public class MobileInput : InputService
    {
        public override event Action OnTouchStart;
        public override event Action OnTouchEnd;

        protected override void HandleInput()
        {
            if (!EnableInput)
                return;
            
            if (Input.touchCount <= 0) 
                return;
            
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    OnTouchStart?.Invoke();
                    break;
                case TouchPhase.Ended:
                    OnTouchEnd?.Invoke();
                    break;
            }
        }

        public override Vector2 GetTouchPosition()
        {
            if (Input.touchCount <= 0)
                return Vector2.zero;
            
            Touch touch = Input.GetTouch(0);
            return touch.position;
        }

        public override bool IsPointerOverUIGameObject()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
            
            return false;
        }
    }
}