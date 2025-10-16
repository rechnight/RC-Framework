// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using UnityEditor;
using UnityEngine;

namespace RCFramework.Tools
{
    [Serializable]
    public class SceneData
    {
        [SerializeField] private SceneAsset _sceneAsset;
        [SerializeField] private SceneSlot _sceneSlot;

        public SceneKey SceneKey
        {
            get
            {
                if (_sceneAsset == null) 
                    return default;
                
                return new SceneKey(_sceneAsset.name);
            }
        }

        public string SceneName => _sceneAsset ? _sceneAsset.name : string.Empty;
        public SceneSlot SceneSlot => _sceneSlot;
    }
}
