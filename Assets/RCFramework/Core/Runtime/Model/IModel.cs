// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface IModel : IGetUtility, ISendEvent
    {
        bool Initialized { get; }
        void Initialize();
        void Cleanup();
    }
}
