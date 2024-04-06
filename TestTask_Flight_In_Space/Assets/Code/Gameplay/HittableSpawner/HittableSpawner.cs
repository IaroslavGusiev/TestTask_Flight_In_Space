using UnityEngine;
using System.Linq;
using VContainer.Unity;
using System.Threading;
using Code.Infrastructure;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

namespace Code.Gameplay
{
    public class HittableSpawner : IAsyncStartable
    {
        private readonly IGameFactory _gameFactory;
        private readonly ViewportBounds _viewportBounds;
        private readonly List<Asteroid> _asteroids = new();

        public HittableSpawner(IGameFactory gameFactory, ViewportBounds viewportBounds)
        {
            _gameFactory = gameFactory;
            _viewportBounds = viewportBounds;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            Transform container = CreateContainer();

            for (var i = 0; i < 5; i++)
            {
                Asteroid asteroid = await _gameFactory.CreateAsteroid(container);
                asteroid.Enable(false);
                _asteroids.Add(asteroid);
            }
            
            SpawnAsteroid();
        }

        private void SpawnAsteroid()
        {
            Asteroid freeAsteroid = _asteroids.FirstOrDefault(x => x.IsFree);
            if (freeAsteroid != null) 
                freeAsteroid.SetToGame(_viewportBounds.GetRandomTopPoint(), _viewportBounds.GetYBottomPoint(), 1.5f);
        }

        private Transform CreateContainer() => 
            new GameObject("Hittable").transform;
    }
}