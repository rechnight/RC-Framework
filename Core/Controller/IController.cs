// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface IController : IGetModel, IGetSystem, IGetUtility,
        IListenEvent, ISendCommand, IInjectDependency
    {

    }
}
