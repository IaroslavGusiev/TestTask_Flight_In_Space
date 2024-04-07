using UnityEngine;
using Code.Services;
using System.Threading;
using Cysharp.Threading.Tasks;
using Code.Infrastructure.AnalyticsSpace;
using Code.Infrastructure.StateMachineBase;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Code.Infrastructure.AppStateMachineScope
{
    public class CloseGameState : IState
    {
        private readonly IAnalyticsModule _analyticsModule;
        private readonly PlayerDataProvider _playerDataProvider;

        public CloseGameState(PlayerDataProvider playerDataProvider, IAnalyticsModule analyticsModule)
        {
            _playerDataProvider = playerDataProvider;
            _analyticsModule = analyticsModule;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            _playerDataProvider.SavePlayerData();
            _analyticsModule.LogAsteroidCollisionAtTheEndOfGame(_playerDataProvider.Data.CurrentAmountHitsWithAsteroids);
            
#if UNITY_EDITOR
            if (Application.isEditor)
            {
                if (EditorApplication.isPlaying)
                    EditorApplication.isPlaying = false;
            }
#else
            Application.Quit();
#endif
        }

        public async UniTask Exit() { }
    }
}