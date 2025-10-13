// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Core
{
    public abstract class ModelBase: IModel
    {
        public event Action OnDataModified;

        public bool Initialized { get; private set; }

        void IModel.Initialize()
        {
            Initialized = true;
            Initialize();
        }

        void IModel.Cleanup()
        {
            Cleanup();
            Initialized = false;
        }

        protected abstract void Initialize();
        protected virtual void Cleanup() { }

        protected void SetDataAsDirty() => OnDataModified.Invoke();
    }
}