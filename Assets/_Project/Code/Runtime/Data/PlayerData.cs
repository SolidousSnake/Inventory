using System.Collections.Generic;
using _Project.Code.Runtime.Gameplay.Stats;

namespace _Project.Code.Runtime.Data
{
    [System.Serializable]
    public class PlayerData
    {
        public PlayerStats PlayerStats = new();
        public List<InventorySaveData> InventoryItems = new();
    }
}