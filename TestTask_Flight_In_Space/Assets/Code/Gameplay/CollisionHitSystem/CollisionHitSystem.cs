using System;
using UnityEngine;
using Code.Services;
using System.Threading;
using VContainer.Unity;
using Code.Infrastructure;
using Cysharp.Threading.Tasks;

namespace Code.Gameplay
{
    public class CollisionHitSystem : ICollisionHitSystem, IAsyncStartable
    {
        public event Action OnHitAmountChange;
        
        public int CurrentHitAmount { get; set; }
        
        private readonly IGameFactory _gameFactory;
        private readonly PlayerDataProvider _playerDataProvider;
        private ParticleSystem _hitVFX;

        public CollisionHitSystem(IGameFactory gameFactory, PlayerDataProvider playerDataProvider)
        {
            _gameFactory = gameFactory;
            _playerDataProvider = playerDataProvider;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            GameObject gameObject = await _gameFactory.CreateHitVFX();
            _hitVFX = gameObject.GetComponent<ParticleSystem>();
        }

        public void RegisterHit(Vector3 hitPosition)
        {
            CurrentHitAmount++;
            SetAmountToPlayerData();
            OnHitAmountChange?.Invoke();
            PlayVFX(hitPosition).Forget();
        }

        private void SetAmountToPlayerData() => 
            _playerDataProvider.Data.CurrentAmountHitsWithAsteroids = CurrentHitAmount; // TODO: for the test task we will overwrite the amount for each session.

        private async UniTaskVoid PlayVFX(Vector3 hitPosition)
        {
            _hitVFX.Play();
            _hitVFX.transform.position = hitPosition;
            await UniTask.Delay(TimeSpan.FromSeconds(1), ignoreTimeScale: false);
            _hitVFX.Stop();
        }
    }
}