using System.Collections.Generic;
using System.IO;
using _Project.Code.Runtime.Core.Util;
using _Project.Code.Runtime.Data;
using _Project.Code.Runtime.Gameplay.Stats;
using Newtonsoft.Json;
using UnityEngine.Device;

namespace _Project.Code.Runtime.Services.SaveLoad
{
    public class JsonSaveLoadService : ISaveLoadService
    {
        private readonly string _filePath = Application.persistentDataPath + Constants.AssetPath.PlayerProgress;

        public void Save(PlayerData data)
        {
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(_filePath, json);
        }

        public PlayerData Load()
        {
            if (!File.Exists(_filePath))
                return new PlayerData { InventoryItems = new List<InventorySaveData>(), PlayerStats = new PlayerStats()};

            string json = File.ReadAllText(_filePath);
            PlayerData progress = JsonConvert.DeserializeObject<PlayerData>(json);
            return progress;
        }

        public void Reset() => Save(new PlayerData());
    }
}