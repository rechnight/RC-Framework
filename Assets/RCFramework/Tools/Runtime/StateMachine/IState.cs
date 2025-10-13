// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Tools
{
    public interface IState
    {
        void OnEnter();
        void OnUpdate();
        void OnFixedUpdate();
        void OnExit();
    }
}
