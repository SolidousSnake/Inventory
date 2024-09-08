using _Project.Code.Runtime.Config;

namespace _Project.Code.Runtime.Gameplay.Inventory
{
    public class InventoryItem
    {
        public ItemConfig ItemConfig { get; }
        public int Quantity { get; set; }

        public InventoryItem(ItemConfig itemConfig, int quantity)
        {
            ItemConfig = itemConfig;
            Quantity = quantity;
        }
    }
}