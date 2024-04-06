using System;
using UnityEngine;

namespace Code.Gameplay
{
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider2D> OnTriggerEnter; 
        public event Action<Collider2D> OnTriggerExit; 
        
        private void OnTriggerEnter2D(Collider2D incomeCollider2D) => 
            OnTriggerEnter?.Invoke(incomeCollider2D);

        private void OnTriggerExit2D(Collider2D outcomeCollider2D) => 
            OnTriggerExit?.Invoke(outcomeCollider2D);
    }
}