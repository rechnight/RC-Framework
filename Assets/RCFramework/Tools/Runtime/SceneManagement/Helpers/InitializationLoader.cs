// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using RCFramework.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RCFramework.Tools
{
    public class InitializationLoader : ControllerBase
    {
        [SerializeField] private SceneData _persistentScene;
        [SerializeField] private SceneData _sceneToLoad;

        private async void Start()
        {
            await SceneManager.LoadSceneAsync(_persistentScene.SceneName, LoadSceneMode.Additive);

            this.GetUtility<SceneLoader>().CreateTransition()
                .Load(_sceneToLoad.SceneSlot, _sceneToLoad.SceneKey, true)
                .Execute();

            await SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }
}