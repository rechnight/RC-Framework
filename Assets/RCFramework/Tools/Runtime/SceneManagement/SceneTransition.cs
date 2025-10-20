// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Collections.Generic;

namespace RCFramework.Tools
{
    public class SceneTransition
    {
        private readonly SceneLoader _sceneLoader;

        public Dictionary<SceneSlot, SceneKey> ScenesToLoad { get; } = new();
        public List<SceneSlot> ScenesToUnload { get; } = new();
        public SceneKey ActiveSceneKey { get; private set; }
        public bool UnloadUnusedAssets { get; private set; } = false;
        public bool FadeOverlay { get; private set; } = false;

        public SceneTransition(SceneLoader sceneLoader) => _sceneLoader = sceneLoader;

        public void Execute() => _sceneLoader.Execute(this);

        public SceneTransition Load(SceneSlot slot, SceneKey sceneKey, bool setActive = false)
        {
            ScenesToLoad[slot] = sceneKey;
            if (setActive)
            {
                ActiveSceneKey = sceneKey;
            }
            return this;
        }

        public SceneTransition Load(ISceneData sceneData, bool setActive = false)
        {
            return Load(sceneData.SceneSlot, sceneData.SceneKey, setActive);
        }

        public SceneTransition Load(SceneSlot slot, string sceneName, bool setActive = false)
        {
            return Load(slot, (SceneKey)sceneName, setActive);
        }

        public SceneTransition Unload(SceneSlot slot)
        {
            ScenesToUnload.Add(slot);
            return this;
        }

        public SceneTransition WithOverlay(bool fade)
        {
            FadeOverlay = fade;
            return this;
        }

        public SceneTransition WithUnloadUnusedAssets(bool unload)
        {
            UnloadUnusedAssets = unload;
            return this;
        }
    }
}
