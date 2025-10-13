// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using RCFramework.Core;

namespace RCFramework.Tools
{
    public abstract class UIPanel : ControllerBase, IUIPanel
    {
        [Inject] protected readonly IUIManager _uiManager;

        private void Start()
        {
            _uiManager.Register(this);
        }

        private void OnDestroy()
        {
            _uiManager.Unregister(this);
        }

        void IUIPanel.Initialize()
        {
            OnInitialize();
            gameObject.SetActive(false);
        }
        void IUIPanel.Open()
        {
            gameObject.SetActive(true);
            OnOpen();
        }
        void IUIPanel.Close()
        {
            gameObject.SetActive(false);
            OnClose();
        }

        public void CloseSelf() => ((IUIPanel)this).Close();

        protected abstract void OnInitialize();
        protected virtual void OnOpen() { }
        protected virtual void OnClose() { }
    }
}