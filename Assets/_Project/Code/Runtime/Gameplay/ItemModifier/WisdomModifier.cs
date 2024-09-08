using _Project.Code.Runtime.Gameplay.Unit.Facade;
using UnityEngine;

namespace _Project.Code.Runtime.Gameplay.ItemModifier
{
    [CreateAssetMenu(menuName = "Source/Inventory/Item Modifier/Wisdom")]
    public class WisdomModifier : ItemModifier
    {
        [SerializeField] private float _value;

        public override void Modify(PlayerFacade player) => player.StatsController.SetWisdom(_value);
    }
}