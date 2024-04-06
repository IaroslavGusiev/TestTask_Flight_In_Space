using DG.Tweening;

namespace Code.Extensions
{
    public static class TweenExtensions
    {
        public static void KillIfValid(this Tween tween, bool complete = false)
        {
            if (tween?.IsActive() ?? false)
                tween.Kill(complete);
        }
    }
}