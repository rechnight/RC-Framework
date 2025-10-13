// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Tools
{
    public class State: IState
    {
        public delegate void StateDelegate();
        public StateDelegate OnEnterDelegate { get; set; }
        public StateDelegate OnExitDelegate { get; set; }
        public StateDelegate OnUpdateDelegate { get; set; }
        public StateDelegate OnFixedUpdateDelegate { get; set; }

        public void OnEnter() => OnEnterDelegate?.Invoke();
        public void OnUpdate() => OnUpdateDelegate?.Invoke();
        public void OnFixedUpdate() => OnFixedUpdateDelegate?.Invoke();
        public void OnExit() => OnExitDelegate?.Invoke();
    }
}