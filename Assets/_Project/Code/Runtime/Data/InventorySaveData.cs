namespace _Project.Code.Runtime.Data
{
    [System.Serializable]
    public class InventorySaveData
    {
        public string Name;
        public int Quantity;

        public InventorySaveData(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}