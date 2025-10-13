// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RCFramework.Tools.Editor
{
    public sealed class HierarchyObjectProcessor : IProcessSceneWithReport
    {
        public int callbackOrder => 0;

        public void OnProcessScene(Scene scene, BuildReport report)
        {
            var hierarchyObjects = scene.GetRootGameObjects()
                .SelectMany(x => x.GetComponentsInChildren<HierarchyObject>())
                .Where(x => x != null)
                .OrderByDescending(x => GetDepth(x.transform));

            foreach (var obj in hierarchyObjects)
            {
                if (obj == null) continue;

                switch (obj.ObjectMode)
                {
                    case HierarchyObject.Mode.None:
                        break;
                    case HierarchyObject.Mode.RemoveInPlay:
                        obj.transform.DetachChildren();
                        Object.DestroyImmediate(obj.gameObject);
                        break;
                    case HierarchyObject.Mode.RemoveInBuild:
                        if (EditorApplication.isPlaying) break;
                        obj.transform.DetachChildren();
                        Object.DestroyImmediate(obj.gameObject);
                        break;
                }
            }
        }

        static int GetDepth(Transform transform)
        {
            var depth = 0;
            var parent = transform.parent;
            while (parent != null)
            {
                depth++;
                parent = parent.parent;
            }
            return depth;
        }
    }
}