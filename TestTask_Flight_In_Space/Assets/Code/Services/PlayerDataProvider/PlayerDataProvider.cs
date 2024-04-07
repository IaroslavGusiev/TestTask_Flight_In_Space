using Code.Data;

namespace Code.Services
{
    public class PlayerDataProvider
    {
        private const string DataKey = "PlayerDataKey";
        public PlayerData Data { get; private set; }

        private readonly ISaveLoadService _saveLoadService;

        public PlayerDataProvider(ISaveLoadService saveLoadService) => 
            _saveLoadService = saveLoadService;

        public void LoadPlayerData() => 
            Data = _saveLoadService.Load<PlayerData>(DataKey) ?? new PlayerData();

        public void SavePlayerData() => 
            _saveLoadService.Save(DataKey, Data);
    }
}