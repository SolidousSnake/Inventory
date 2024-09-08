using _Project.Code.Runtime.Config;
using UnityEngine;

namespace _Project.Code.Runtime.Gameplay.Inventory
{
    public class CollectableItem : MonoBehaviour
    {
        [SerializeField] private ItemConfig _itemConfig;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Inventory inventory))
            {
                inventory.AddItem(_itemConfig);
                Destroy(gameObject);
            }
        }
    }
}