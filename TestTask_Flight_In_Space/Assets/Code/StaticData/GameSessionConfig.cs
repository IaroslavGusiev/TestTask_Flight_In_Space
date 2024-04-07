using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "GameSessionConfig", menuName = "ScriptableObject/GameSessionConfig")]
    public class GameSessionConfig : ScriptableObject
    {
        [field: SerializeField] public float HittableFlySpeed { get; private set; }
        [field: SerializeField] public float SpaceShipFlySpeed { get; private set; }
        [field: SerializeField] public float IntervalForSpawnOfHittable { get; private set; }
    }
}