// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEditor;
using UnityEngine;

namespace RCFramework.Tools
{
    [AddComponentMenu("RC Framework/Hierarchy Separator")]
    public sealed class HierarchySeparator : HierarchyObject
    {
        [MenuItem("GameObject/RC Framework/Hierarchy Separator", false)]
        static void CreateSeparator(MenuCommand menuCommand)
        {
            var obj = new GameObject("Separator");
            obj.AddComponent<HierarchySeparator>();
            GameObjectUtility.SetParentAndAlign(obj, menuCommand.context as GameObject);
            Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
            Selection.activeObject = obj;
        }
    }
}