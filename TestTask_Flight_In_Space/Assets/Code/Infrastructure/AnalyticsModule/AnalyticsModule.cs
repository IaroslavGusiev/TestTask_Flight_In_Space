using UnityEngine;
using Firebase.Analytics;

namespace Code.Infrastructure.AnalyticsSpace
{
    public class AnalyticsModule : IAnalyticsModule
    {
        private const string AsteroidCollisions = "AsteroidCollisions";
        private const string GameEnded = "Last_Player_Result";

        public void LogThatSceneWasLoaded(string sceneName)
        {
            FirebaseAnalytics.LogEvent(sceneName);
#if UNITY_EDITOR
            Debug.Log($"<color=yellow> analytics message: {sceneName} </color>");
#endif
        }

        public void LogAsteroidCollisionAtTheEndOfGame(int numCollisions)
        {
            FirebaseAnalytics.LogEvent(GameEnded, new Parameter(AsteroidCollisions, numCollisions));
            
#if UNITY_EDITOR
            Debug.Log($"<color=yellow> analytics message: GameEnded - {AsteroidCollisions + numCollisions} </color>");
#endif
        }
    }
}