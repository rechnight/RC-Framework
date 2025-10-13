// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface ISystem : IGetModel, IGetSystem, IGetUtility,
        IListenEvent, ISendEvent, IInjectDependency
    {
        bool Initialized { get; }
        void Initialize();
        void Cleanup();
        void TrackUnsubscriber(IUnsubscriber unsubscriber);
    }
}
