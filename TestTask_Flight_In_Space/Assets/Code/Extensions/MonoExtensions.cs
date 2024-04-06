using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Code.Extensions
{
    public static class MonoExtensions
    {
        public static void TryToStopCoroutine(this MonoBehaviour mono, Coroutine coroutine)
        {
            if(coroutine != null)
                mono.StopCoroutine(coroutine);
        }  
        
        public static void Add(this Button button, UnityAction action) =>
            button.onClick.AddListener(action);

        public static void Remove(this Button button, UnityAction action) =>
            button.onClick.RemoveListener(action);
    }
}