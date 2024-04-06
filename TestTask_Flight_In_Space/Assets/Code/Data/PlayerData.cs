using System;

namespace Code.Data
{
    [Serializable]
    public class PlayerData
    {
        public int CurrentAmountHitsWithAsteroids;
        public Vector3Data SavedPositionFromLastGame;
    }
}