using _Project.Code.Runtime.Gameplay.Unit.Facade;
using UnityEngine;

namespace _Project.Code.Runtime.Gameplay.ItemModifier
{
    public abstract class ItemModifier : ScriptableObject
    {
        public abstract void Modify(PlayerFacade player);
    }
}