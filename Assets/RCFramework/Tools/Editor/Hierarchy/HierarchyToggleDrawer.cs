// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEditor;
using UnityEngine;

namespace RCFramework.Tools.Editor
{
    public sealed class HierarchyToggleDrawer : HierarchyDrawer
    {
        public override void OnGUI(int instanceID, Rect selectionRect)
        {
            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) return;
            if (gameObject.TryGetComponent<HierarchyObject>(out _)) return;

            var rect = selectionRect;
            rect.x = rect.xMax - 2.7f;
            rect.width = 16f;

            var active = GUI.Toggle(rect, gameObject.activeSelf, string.Empty);
            if (active != gameObject.activeSelf)
            {
                Undo.RecordObject(gameObject, $"{(active ? "Activate" : "Deactivate")} GameObject '{gameObject.name}'");
                gameObject.SetActive(active);
                EditorUtility.SetDirty(gameObject);
            }
        }
    }

}