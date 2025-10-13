// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEditor;
using UnityEngine;

namespace RCFramework.Tools.Editor
{
    public sealed class HierarchySeparatorDrawer : HierarchyDrawer
    {
        static Color SeparatorColor => new(0.5f, 0.5f, 0.5f);

        public override void OnGUI(int instanceID, Rect selectionRect)
        {
            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) return;
            if (!gameObject.TryGetComponent<HierarchySeparator>(out _)) return;

            DrawBackground(instanceID, selectionRect);

            var lineRect = selectionRect.AddY(selectionRect.height * 0.5f).AddXMax(14f).SetHeight(1f);
            EditorGUI.DrawRect(lineRect, SeparatorColor);
        }
    }
}