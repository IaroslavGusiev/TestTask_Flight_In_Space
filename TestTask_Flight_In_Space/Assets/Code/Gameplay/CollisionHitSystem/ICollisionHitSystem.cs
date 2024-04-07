using System;
using UnityEngine;

namespace Code.Gameplay
{
    public interface ICollisionHitSystem
    {
        event Action OnHitAmountChange;
        int CurrentHitAmount { get; }
        void RegisterHit(Vector3 hitPosition);
    }
}