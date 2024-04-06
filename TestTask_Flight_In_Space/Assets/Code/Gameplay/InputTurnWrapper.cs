using System;
using UnityEngine;
using Code.StaticData;
using VContainer.Unity;
using Code.Services.InputServiceSpace;

namespace Code.Gameplay
{
    public class InputTurnWrapper : IStartable, IDisposable
    {
        public event Action<TurnDirection> OnTurnAction;
        
        private readonly IInputService _inputService;
        private float _screenWidthHalf;

        public InputTurnWrapper(IInputService inputService) => 
            _inputService = inputService;

        public void Start()
        {
            _screenWidthHalf = Screen.width / 2f;
            _inputService.OnTouchStart += HandleStartOfTouch;
            _inputService.OnTouchEnd += HandleEndOfTouch;
        }

        public void Dispose()
        {
            _inputService.OnTouchStart += HandleStartOfTouch;
            _inputService.OnTouchEnd += HandleEndOfTouch;
        }

        private void HandleStartOfTouch()
        {
            Vector2 touchPosition = _inputService.GetTouchPosition();
            
            if (touchPosition.x < _screenWidthHalf)
                OnTurnAction?.Invoke(TurnDirection.LeftTurn);
            else if (touchPosition.x >= _screenWidthHalf)
                OnTurnAction?.Invoke(TurnDirection.RightTurn);
        }

        private void HandleEndOfTouch() => 
            OnTurnAction?.Invoke(TurnDirection.StopTurn);
    }
}