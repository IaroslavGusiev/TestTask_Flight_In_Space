using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Services.InputServiceSpace
{
    public class EditorInput : InputService
    {
        public override event Action OnTouchStart;
        public override event Action OnTouchEnd;

        protected override void HandleInput()
        {
            if (!EnableInput)
                return;
            
            if (Input.GetMouseButtonDown(0))
                OnTouchStart?.Invoke();
            if (Input.GetMouseButtonUp(0))
                OnTouchEnd?.Invoke();
        }

        public override Vector2 GetTouchPosition() =>
            Input.mousePosition;
        
        public override bool IsPointerOverUIGameObject() => 
            EventSystem.current.IsPointerOverGameObject();
    }
}