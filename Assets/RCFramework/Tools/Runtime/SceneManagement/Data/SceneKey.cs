// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Tools
{
    public readonly struct SceneKey
    {
        public string SceneName { get; }

        public SceneKey(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Scene name cannot be null or empty", nameof(name));
            
            SceneName = name;
        }

        public override string ToString() => SceneName;

        public static implicit operator string(SceneKey scene) => scene.SceneName;
        public static implicit operator SceneKey(string name) => new SceneKey(name);
    }
}