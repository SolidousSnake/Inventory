using Cysharp.Threading.Tasks;

namespace _Project.Code.Runtime.Core.SceneManagement
{
    public interface ISceneLoader
    {
        public UniTask Load(string nextScene);
    }
}