// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Core
{
    public class Architecture : IArchitecture
    {
        private readonly IIOCContainer _container = new IOCContainer();
        private readonly IEventBus _eventBus = new EventBus();

        private static Architecture _instance;

        public static Architecture Instance => _instance ??= new Architecture();

        T IArchitecture.GetModel<T>() => _container.Resolve<T>();
        void IArchitecture.RegisterModel<T>(T model) => _container.Register(model);
        void IArchitecture.UnregisterModel<T>(T model)
        {
            model.Cleanup();
            _container.Unregister(model);
        }

        T IArchitecture.GetSystem<T>() => _container.Resolve<T>();
        void IArchitecture.RegisterSystem<T>(T system) => _container.Register(system);
        void IArchitecture.UnregisterSystem<T>(T system)
        {
            system.Cleanup();
            _container.Unregister(system);
        }

        T IArchitecture.GetUtility<T>() => _container.Resolve<T>();
        void IArchitecture.RegisterUtility<T>(T utility) => _container.Register(utility);
        void IArchitecture.UnregisterUtility<T>(T utility) => _container.Unregister(utility);

        void IArchitecture.SendCommand(ICommand command) => command.Execute();
        T IArchitecture.SendCommand<T>(ICommand<T> command) => command.Execute();

        void IArchitecture.SendEvent<T>(T eventData) => _eventBus.Raise(eventData);
        EventBinding<T> IArchitecture.StartListening<T>(Action<T> onArgsEvent) => _eventBus.Subscribe(onArgsEvent);
        EventBinding<T> IArchitecture.StartListening<T>(Action onEvent) => _eventBus.Subscribe<T>(onEvent);
        void IArchitecture.StopListening<T>(EventBinding<T> binding) => _eventBus.Unsubscribe(binding);

        void IArchitecture.InjectDependency(object obj) => _container.Inject(obj);

        void IArchitecture.Load()
        {
            foreach (IModel model in _container.GetInstancesByType<IModel>())
            {
                if (!model.Initialized)
                {
                    model.Initialize();
                }
            }

            foreach (ISystem system in _container.GetInstancesByType<ISystem>())
            {
                if (!system.Initialized)
                {
                    system.Initialize();
                }
            }
        }

        void IArchitecture.Unload()
        {
            _eventBus.Clear();
            _container.Clear();
            _instance = null;
        }
    }
}