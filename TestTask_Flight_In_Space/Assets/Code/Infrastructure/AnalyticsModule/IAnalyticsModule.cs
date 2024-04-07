namespace Code.Infrastructure.AnalyticsSpace
{
    public interface IAnalyticsModule
    {
        void LogThatSceneWasLoaded(string sceneName);
        void LogAsteroidCollisionAtTheEndOfGame(int numCollisions);
    }
}