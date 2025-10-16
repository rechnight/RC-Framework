// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using RCFramework.Core;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RCFramework.Tools
{
    [DefaultExecutionOrder(-2000)]
    [DisallowMultipleComponent]
    public class EditorColdStartup : ControllerBase
    {
        [SerializeField] private SceneData _currentScene;
        [SerializeField] private SceneData _persistentScene;
        [SerializeField] private List<SceneData> _scenesToLoad;

        protected override async void Awake()
        {
            if (SceneManager.sceneCount == 1)
            {
                foreach (var root in gameObject.scene.GetRootGameObjects())
                {
                    if (root != gameObject)
                        root.SetActive(false);
                }

                await SceneManager.LoadSceneAsync(_persistentScene.SceneName, LoadSceneMode.Additive);
                await SceneManager.UnloadSceneAsync(gameObject.scene);

                var transitionBuilder = this.GetUtility<SceneLoader>().CreateTransition();
                foreach (var scene in _scenesToLoad)
                {
                    transitionBuilder = transitionBuilder.Load(scene.SceneSlot, scene.SceneKey);
                }
                transitionBuilder.Load(_currentScene.SceneSlot, _currentScene.SceneKey, true)
                    .Execute();
            }
        }
    }
}
