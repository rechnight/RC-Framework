// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public abstract class SystemBase: ISystem
    {
        private readonly UnsubscribeHandler _unsubscribeHandler = new();

        public bool Initialized { get; private set; }

        void ISystem.Initialize()
        {
            if (Initialized)
                return;

            this.InjectDependency(this);
            Initialize();
            Initialized = true;
        }

        void ISystem.Cleanup()
        {
            Cleanup();
            Initialized = false;
        }

        void ISystem.TrackUnsubscriber(IUnsubscriber unsubscriber)
        {
            _unsubscribeHandler.AddUnsubscriber(unsubscriber);
        }

        protected abstract void Initialize();
        protected virtual void Cleanup() { }
    }
}