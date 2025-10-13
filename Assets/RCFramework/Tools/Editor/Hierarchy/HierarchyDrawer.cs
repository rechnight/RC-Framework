// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using UnityEditor;
using UnityEngine;

namespace RCFramework.Tools.Editor
{
    public abstract class HierarchyDrawer
    {
        public abstract void OnGUI(int instanceID, Rect selectionRect);

        protected static Rect GetBackgroundRect(Rect selectionRect)
        {
            return selectionRect.AddXMax(20f);
        }

        protected static void DrawBackground(int instanceID, Rect selectionRect)
        {
            var backgroundRect = GetBackgroundRect(selectionRect);

            Color backgroundColor;
            var e = Event.current;
            var isHover = backgroundRect.Contains(e.mousePosition);

            if (Selection.Contains(instanceID))
            {
                backgroundColor = HighlightBackground;
            }
            else if (isHover)
            {
                backgroundColor = HighlightBackgroundInactive;
            }
            else
            {
                backgroundColor = WindowBackground;
            }

            EditorGUI.DrawRect(backgroundRect, backgroundColor);
        }

        private static Color GetColor(string htmlColor)
        {
            if (!ColorUtility.TryParseHtmlString(htmlColor, out var color)) throw new ArgumentException();
            return color;
        }

        private static Color HighlightBackgroundInactive
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return GetColor("#4D4D4D");
                else return GetColor("#AEAEAE");
            }
        }

        private static Color HighlightBackground
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return GetColor("#2C5D87");
                else return GetColor("#3A72B0");
            }
        }

        private static Color WindowBackground
        {
            get
            {
                if (EditorGUIUtility.isProSkin) return GetColor("#383838");
                else return GetColor("#C8C8C8");
            }
        }
    }
}
