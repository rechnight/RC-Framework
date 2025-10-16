// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Collections.Generic;

namespace RCFramework.Tools
{
    public class TransitionBuilder
    {
        private readonly SceneLoader _sceneLoader;

        public Dictionary<SceneSlot, SceneKey> ScenesToLoad { get; } = new();
        public List<SceneSlot> ScenesToUnload { get; } = new();
        public SceneKey ActiveSceneName { get; private set; }
        public bool UnloadUnusedAssets { get; private set; } = false;
        public bool FadeOverlay { get; private set; } = false;

        public TransitionBuilder(SceneLoader sceneLoader) => _sceneLoader = sceneLoader;

        public void Execute() => _sceneLoader.Execute(this);

        public TransitionBuilder Load(SceneSlot slot, SceneKey sceneName, bool setActive = false)
        {
            ScenesToLoad[slot] = sceneName;
            if (setActive)
            {
                ActiveSceneName = sceneName;
            }
            return this;
        }

        public TransitionBuilder Unload(SceneSlot slot)
        {
            ScenesToUnload.Add(slot);
            return this;
        }

        public TransitionBuilder WithOverlay(bool fade)
        {
            FadeOverlay = fade;
            return this;
        }

        public TransitionBuilder WithUnloadUnusedAssets(bool unload)
        {
            UnloadUnusedAssets = unload;
            return this;
        }
    }
}