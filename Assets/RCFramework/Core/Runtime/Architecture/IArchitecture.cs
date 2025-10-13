// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Core
{
    public interface IArchitecture
    {
        void Load();
        void Unload();

        T GetModel<T>() where T : IModel;
        void RegisterModel<T>(T model) where T : IModel;
        void UnregisterModel<T>(T model) where T : IModel;

        T GetSystem<T>() where T : ISystem;
        void RegisterSystem<T>(T system) where T : ISystem;
        void UnregisterSystem<T>(T system) where T : ISystem;

        T GetUtility<T>() where T : IUtility;
        void RegisterUtility<T>(T utility) where T : IUtility;
        void UnregisterUtility<T>(T utility) where T : IUtility;

        void SendCommand(ICommand command);
        TResult SendCommand<TResult>(ICommand<TResult> command);

        void SendEvent<T>(T eventData) where T : IEvent;
        EventBinding<T> StartListening<T>(Action<T> onArgsEvent) where T : IEvent;
        EventBinding<T> StartListening<T>(Action onEvent) where T : IEvent;
        void StopListening<T>(EventBinding<T> binding) where T : IEvent;

        void InjectDependency(object target);
    }
}
