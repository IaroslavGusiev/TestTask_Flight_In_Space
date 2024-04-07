using System;
using UnityEngine;
using System.Linq;
using Code.StaticData;
using VContainer.Unity;
using System.Threading;
using Code.Infrastructure;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using Code.Services.StaticDataService;

namespace Code.Gameplay
{
    public class HittableSpawner : IAsyncStartable
    {
        private readonly IGameFactory _gameFactory;
        private readonly ViewportBounds _viewportBounds;
        private readonly List<Asteroid> _asteroids = new();
        private readonly GameSessionConfig _gameSessionConfig;
        
        private UniTask _spawnHittablesTask;

        public HittableSpawner(IGameFactory gameFactory, ViewportBounds viewportBounds, IStaticDataService staticDataService)
        {
            _gameFactory = gameFactory;
            _viewportBounds = viewportBounds;
            _gameSessionConfig = staticDataService.GetGameSessionConfig();
        }

        public async UniTask StartAsync(CancellationToken cancellation) => 
            await CreateAsteroids();

        public async UniTask StartSpawnHittables(CancellationToken cancellationToken)
        {
            _spawnHittablesTask = LaunchSpawnHittablesTask(cancellationToken);
            await _spawnHittablesTask;
        }

        public void PauseAllActiveHittables()
        {
            foreach (Asteroid asteroid in _asteroids
                         .Where(x => x.IsFree == false))
                asteroid.CanFly = false;
        }
        
        public void UnpauseAllActiveHittables()
        {
            foreach (Asteroid asteroid in _asteroids)
                asteroid.CanFly = true;
        }

        private async UniTask CreateAsteroids()
        {
            Transform container = CreateContainer();
            for (var i = 0; i < 10; i++)
            {
                Asteroid asteroid = await _gameFactory.CreateAsteroid(container);
                asteroid.Enable(false);
                _asteroids.Add(asteroid);
            }
        }

        private async UniTask LaunchSpawnHittablesTask(CancellationToken cancellationToken)
        {
            while (true)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_gameSessionConfig.IntervalForSpawnOfHittable), DelayType.Realtime, PlayerLoopTiming.Update, cancellationToken);
                SpawnAsteroid();
            }
        }

        private void SpawnAsteroid()
        {
            Asteroid freeAsteroid = _asteroids.FirstOrDefault(x => x.IsFree);
            if (freeAsteroid != null) 
                freeAsteroid.SetToGame(_viewportBounds.GetRandomTopPoint(), _viewportBounds.GetYBottomPoint(), _gameSessionConfig.HittableFlySpeed); 
        }

        private Transform CreateContainer() => 
            new GameObject("Hittable").transform;
    }
}