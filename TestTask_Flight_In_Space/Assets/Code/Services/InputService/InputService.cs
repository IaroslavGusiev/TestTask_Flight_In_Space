using System;
using UnityEngine;
using VContainer.Unity;

namespace Code.Services.InputServiceSpace
{
    public abstract class InputService : IInputService, ITickable
    {
        public abstract event Action OnTouchStart;
        public abstract event Action OnTouchEnd;
        
        protected bool EnableInput = true;

        public abstract Vector2 GetTouchPosition();
        
        public abstract bool IsPointerOverUIGameObject();
        
        protected abstract void HandleInput();

        public void Enable(bool enabled) => 
            EnableInput = enabled;

        public void Tick()
        {
            HandleInput();
        }
    }
}