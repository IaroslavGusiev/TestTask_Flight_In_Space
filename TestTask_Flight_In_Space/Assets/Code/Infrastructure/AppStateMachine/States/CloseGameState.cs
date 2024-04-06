using UnityEngine;
using System.Threading;
using Cysharp.Threading.Tasks;
using Code.Infrastructure.StateMachineBase;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Code.Infrastructure.AppStateMachineScope
{
    public class CloseGameState : IState
    {
        public async UniTask Enter(CancellationToken cancellationToken)
        {
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