using Code.UI;
using Code.StaticData;
using System.Threading;
using Cysharp.Threading.Tasks;
using Code.Infrastructure.StateMachineBase;

namespace Code.Infrastructure.AppStateMachineScope
{
    public class MainMenuState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;

        public MainMenuState(ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain)
        {
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            _loadingCurtain.Show();
            await _sceneLoader.LoadAsync(SceneName.MainMenu, OnLoadedScene); 
        }

        public async UniTask Exit() { }
        
        private void OnLoadedScene() => 
            _loadingCurtain.Hide();
    }
}