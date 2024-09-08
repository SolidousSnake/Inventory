using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Code.Runtime.Core.SceneManagement
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask Load(string nextScene)
        {   
            AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
            
            while (!operation.isDone)
            {
                await UniTask.Yield();
            }
        }
    }
}