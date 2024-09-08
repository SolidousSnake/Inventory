using UniRx;
using UnityEngine;

namespace _Project.Code.Runtime.Gameplay.Stats
{
    [CreateAssetMenu(menuName = "Source/Player/Stats", fileName = "New stats")]
    public class PlayerStats : ScriptableObject
    {
        public FloatReactiveProperty Health = new();
        public FloatReactiveProperty Strength = new();
        public FloatReactiveProperty Stamina = new();
        public FloatReactiveProperty Wisdom = new();
        public FloatReactiveProperty MovementSpeed = new();
    }
}