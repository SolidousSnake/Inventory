using UnityEngine;

namespace _Project.Code.Runtime.Config
{
    [CreateAssetMenu(menuName = "Source/Level/Config", fileName = "New level config")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public Vector3 PlayerSpawnPoint { get; private set; }
    }
}