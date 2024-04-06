using UnityEngine;

namespace Code.Gameplay
{
    public class LevelBehaviour : MonoBehaviour
    {
        [field: SerializeField] public Transform ShipSpawnPosition { get; private set; }
        [field: SerializeField] public BackgroundScroller BackgroundScroller { get; private set; }

        public void LateUpdate() => 
            BackgroundScroller.LaunchScroll();
    }
}