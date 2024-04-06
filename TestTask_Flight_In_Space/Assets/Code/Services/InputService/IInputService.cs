using System;
using UnityEngine;

namespace Code.Services.InputServiceSpace
{
    public interface IInputService 
    {
        event Action OnTouchStart;
        event Action OnTouchEnd;

        void Enable(bool enabled);
        Vector2 GetTouchPosition();
        bool IsPointerOverUIGameObject();
    }
}