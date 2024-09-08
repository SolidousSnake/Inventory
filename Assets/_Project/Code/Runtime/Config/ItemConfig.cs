using _Project.Code.Runtime.Gameplay.ItemModifier;
using UnityEngine;

namespace _Project.Code.Runtime.Config
{
    [CreateAssetMenu(menuName = "Source/Inventory/Item", fileName = "New Inventory Item")]
    public class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int MaxStack { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public ItemModifier Modifier { get; private set; }
    }
}