using _Project.Code.Runtime.Data;

namespace _Project.Code.Runtime.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        public void Save(PlayerData data);
        public PlayerData Load();
        public void Reset();
    }
}