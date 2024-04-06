using UnityEngine;
using System.Collections.Generic;

namespace Services.ScreenServiceSpace
{
    public class ChildScreensProvider : MonoBehaviour, IScreensProvider
    {
        public IEnumerable<BaseScreen> GetScreens() =>
            GetComponentsInChildren<BaseScreen>(true);
    }
}