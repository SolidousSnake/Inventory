﻿using _Project.Code.Runtime.Gameplay.Unit.Facade;
using UnityEngine;

namespace _Project.Code.Runtime.Gameplay.ItemModifier
{
    [CreateAssetMenu(menuName = "Source/Inventory/Item Modifier/Damage")]
    public class DamageModifier : ItemModifier
    {
        [SerializeField] private float _value;
        
        public override void Modify(PlayerFacade player) => player.Health.ApplyDamage(_value);
    }
}