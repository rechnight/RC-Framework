// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface IGetModel : IGetArchitecture { }

    public static class IGetModelExtensions
    {
        public static T GetModel<T>(this IGetModel self) where T : IModel
        {
            return self.GetArchitecture().GetModel<T>();
        }
    }
}