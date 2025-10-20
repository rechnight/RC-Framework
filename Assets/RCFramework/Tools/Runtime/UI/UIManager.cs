// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;
using System.Collections.Generic;
using System;
using RCFramework.Core;

namespace RCFramework.Tools
{
    public class UIManager : IUtility
    {
        private readonly Dictionary<Type, IUIPanel> _panels = new();

        public void Register(IUIPanel panel)
        {
            var type = panel.GetType();
            if (!_panels.ContainsKey(type))
            {
                _panels[type] = panel;
                panel.Initialize();
            }
        }

        public void Unregister(IUIPanel panel)
        {
            var type = panel.GetType();
            _panels.Remove(type);
        }

        public void OpenPanel<T>() where T : IUIPanel
        {
            GetPanel<T>()?.Open();
        }

        public void ShowPanel<T>() where T : UIPanel
        {
            GetPanel<T>()?.gameObject.SetActive(true);
        }

        public void ClosePanel<T>() where T : IUIPanel
        {
            GetPanel<T>()?.Close();
        }

        public void HidePanel<T>() where T : UIPanel
        {
            GetPanel<T>()?.gameObject.SetActive(false);
        }

        private T GetPanel<T>() where T : IUIPanel
        {
            if (_panels.TryGetValue(typeof(T), out IUIPanel panel))
            {
                return (T)panel;
            }
            return default;
        }
    }
}

