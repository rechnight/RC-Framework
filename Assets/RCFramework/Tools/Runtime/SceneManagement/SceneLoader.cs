// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using RCFramework.Core;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RCFramework.Tools
{
    public class SceneLoader : IUtility
    {
        private readonly Dictionary<SceneSlot, SceneKey> _loadedScenes = new();
        private LoadingOverlay _loadingOverlay;
        private AsyncOperationGroup _loadingOperationGroup;
        private bool _isLoading;

        public EventChannel<SceneKey> SceneLoaded = new();
        public EventChannel<SceneKey> SceneUnloaded = new();
        public EventChannel SceneGroupLoaded = new();

        public TransitionBuilder CreateTransition() => new TransitionBuilder(this);

        public async void Execute(TransitionBuilder builder)
        {
            if (_isLoading)
                return;

            _isLoading = true;

            if (builder.FadeOverlay && _loadingOverlay != null)
            {
                await _loadingOverlay.FadeIn();
            }

            await UnloadSceneAsync(builder.ScenesToUnload);

            if (builder.UnloadUnusedAssets)
            {
                await UnloadUnusedAssets();
            }

            await LoadSceneAsync(builder.ScenesToLoad);

            while (!_loadingOperationGroup.IsDone)
            {
                if (_loadingOverlay != null)
                {
                    _loadingOverlay.Report(_loadingOperationGroup.Progress);
                }
                await Awaitable.NextFrameAsync();
            }

            if (builder.ActiveSceneName != null)
            {
                Scene activeScene = SceneManager.GetSceneByName(builder.ActiveSceneName.SceneName);
                if (activeScene.IsValid() && activeScene.isLoaded)
                {
                    SceneManager.SetActiveScene(activeScene);
                }
            }

            if (builder.FadeOverlay && _loadingOverlay != null)
            {
                await _loadingOverlay.FadeOut();
            }

            SceneGroupLoaded?.Raise();
            _isLoading = false;
        }

        public void ChangeSlot(SceneSlot from, SceneSlot to, bool setActive = false)
        {

            if (_isLoading || !_loadedScenes.ContainsKey(from))
                return;

            SceneKey sceneName = _loadedScenes[from];
            _loadedScenes[to] = sceneName;
            _loadedScenes.Remove(from);

            if (setActive)
            {
                Scene scene = SceneManager.GetSceneByName(sceneName.SceneName);
                if (scene.IsValid() && scene.isLoaded)
                {
                    SceneManager.SetActiveScene(scene);
                }
            }
        }

        public void SetOverlay(LoadingOverlay overlay) => _loadingOverlay = overlay;

        private async Awaitable UnloadSceneAsync(List<SceneSlot> sceneSlots)
        {
            AsyncOperationGroup unloadingOperationGroup = new AsyncOperationGroup(sceneSlots.Count);

            foreach (var sceneSlot in sceneSlots)
            {
                if (_loadedScenes.TryGetValue(sceneSlot, out var sceneKey) && !string.IsNullOrEmpty(sceneKey.SceneName))
                {
                    AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(sceneKey.SceneName);
                    unloadingOperationGroup.Operations.Add(unloadOperation);
                    _loadedScenes.Remove(sceneSlot);
                    SceneUnloaded?.Raise(sceneKey);
                }
            }

            while (!unloadingOperationGroup.IsDone)
            {
                await Awaitable.NextFrameAsync();
            }
        }

        private async Awaitable LoadSceneAsync(Dictionary<SceneSlot, SceneKey> scenesToLoad)
        {
            _loadingOperationGroup = new AsyncOperationGroup(scenesToLoad.Count);

            foreach (var kvp in scenesToLoad)
            {
                SceneSlot sceneSlot = kvp.Key;
                SceneKey sceneKey = kvp.Value;
                if (_loadedScenes.ContainsKey(sceneSlot))
                {
                    await UnloadSceneAsync(new List<SceneSlot> { sceneSlot });
                }
                AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneKey.SceneName, LoadSceneMode.Additive);
                _loadingOperationGroup.Operations.Add(loadOperation);
                _loadedScenes[sceneSlot] = sceneKey;
                SceneLoaded?.Raise(sceneKey);
            }
        }

        private async Awaitable UnloadUnusedAssets()
        {
            AsyncOperation unloadAssetsOperation = Resources.UnloadUnusedAssets();
            await Awaitable.FromAsyncOperation(unloadAssetsOperation);
        }
    }
}
