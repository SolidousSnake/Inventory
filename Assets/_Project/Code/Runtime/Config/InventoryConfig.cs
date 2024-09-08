using System.Collections.Generic;
using UnityEngine;

namespace _Project.Code.Runtime.Config
{
    [CreateAssetMenu(menuName = "Source/Inventory/Inventory", fileName = "New Inventory")]
    public class InventoryConfig : ScriptableObject
    {
        [SerializeField] private List<ItemConfig> _initialItems;
        [field: SerializeField] public int MaxSize { get; private set; }

        public IReadOnlyList<ItemConfig> InitialItems => _initialItems;
    }
}