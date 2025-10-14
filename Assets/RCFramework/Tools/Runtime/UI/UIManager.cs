// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;
using System.Collections.Generic;
using System;

namespace RCFramework.Tools
{
    public class UIManager : IUIManager
    {
        private readonly Dictionary<Type, IUIPanel> _panels = new();

        void IUIManager.Register(IUIPanel panel)
        {
            var type = panel.GetType();
            if (!_panels.ContainsKey(type))
            {
                _panels[type] = panel;
                panel.Initialize();
            }
        }

         void IUIManager.Unregister(IUIPanel panel)
        {
            var type = panel.GetType();
            _panels.Remove(type);
        }

        void IUIManager.OpenPanel<T>()
        {
            GetPanel<T>()?.Open();
        }

        void IUIManager.ShowPanel<T>()
        {
            GetPanel<T>()?.gameObject.SetActive(true);
        }

        void IUIManager.ClosePanel<T>()
        {
            GetPanel<T>()?.Close();
        }

        void IUIManager.HidePanel<T>()
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
