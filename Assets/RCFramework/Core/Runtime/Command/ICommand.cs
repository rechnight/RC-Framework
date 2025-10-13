// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface ICommand : IGetArchitecture, IGetModel, IGetSystem, IGetUtility,
        ISendCommand, ISendEvent, IInjectDependency
    {
        void Execute();
    }

    public interface ICommand<T> : IGetArchitecture, IGetModel, IGetSystem, IGetUtility,
        ISendCommand, ISendEvent, IInjectDependency
    {
        T Execute();
    }
}
