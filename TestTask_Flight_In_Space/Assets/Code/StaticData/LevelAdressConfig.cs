using UnityEngine;

namespace Code.StaticData
{
    [CreateAssetMenu(fileName = "GameAssetConfig", menuName = "ScriptableObject/GameAssetConfig")]
    public class GameAssetConfig : ScriptableObject
    {
        [field: SerializeField] public string SpaceShipPrefabAddress { get; private set; }
        [field: SerializeField] public string LevelPrefabAddress { get; private set; }
        [field: SerializeField] public string AsteroidPrefabAddress { get; private set; }
    }
}