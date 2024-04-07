using Code.StaticData;
using Cysharp.Threading.Tasks;

namespace Code.Services.StaticDataService
{
    public interface IStaticDataService
    {
        UniTask Initialize();
        GameAssetConfig GetGameAssetConfig();
        GameSessionConfig GetGameSessionConfig();
    }
}