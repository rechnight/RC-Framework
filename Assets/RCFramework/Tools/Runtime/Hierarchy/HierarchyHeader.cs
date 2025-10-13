// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEditor;
using UnityEngine;

namespace RCFramework.Tools
{
    [AddComponentMenu("RC Framework/Hierarchy Header")]
    public sealed class HierarchyHeader : HierarchyObject 
    {
        [MenuItem("GameObject/RC Framework/Hierarchy Header", false)]
        static void CreateHeader(MenuCommand menuCommand)
        {
            var obj = new GameObject("Header");
            obj.AddComponent<HierarchyHeader>();
            GameObjectUtility.SetParentAndAlign(obj, menuCommand.context as GameObject);
            Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
            Selection.activeObject = obj;
        }
    }
}