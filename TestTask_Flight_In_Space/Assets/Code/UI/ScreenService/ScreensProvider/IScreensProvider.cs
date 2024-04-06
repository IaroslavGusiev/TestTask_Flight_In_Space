using System.Collections.Generic;

namespace Services.ScreenServiceSpace
{
    public interface IScreensProvider
    {
        IEnumerable<BaseScreen> GetScreens();
    }
}