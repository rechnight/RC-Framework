// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using RCFramework.Core;
using UnityEngine;

namespace RCFramework.Tools
{
    public interface IUIManager: IUtility
    {
        void Register(IUIPanel panel);
        void Unregister(IUIPanel panel);
        void OpenPanel<T>() where T : IUIPanel;
        void ShowPanel<T>() where T : MonoBehaviour, IUIPanel;
        void ClosePanel<T>() where T : IUIPanel;
        void HidePanel<T>() where T : MonoBehaviour, IUIPanel;
    }
}
