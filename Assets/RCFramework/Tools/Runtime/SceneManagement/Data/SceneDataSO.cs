// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEditor;
using UnityEngine;

namespace RCFramework.Tools
{
    [CreateAssetMenu(fileName = "NewSceneData", menuName = "RC Framework/Scriptable Objects/Scene/Scene Data")]
    public class SceneDataSO : ScriptableObject
    {
        [SerializeField, TextArea] private string _description;
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