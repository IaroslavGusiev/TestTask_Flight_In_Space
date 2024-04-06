using UnityEngine;
using Code.Gameplay;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure
{
    public interface IGameFactory
    {
        UniTask<LevelBehaviour> CreateBattlefieldBehaviour();
        UniTask<Asteroid> CreateAsteroid(Transform container);
        UniTask<ShipBehaviour> CreateShipBehaviour(Vector3 at);
    }
}