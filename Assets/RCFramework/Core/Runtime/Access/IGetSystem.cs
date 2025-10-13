// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface IGetSystem : IGetArchitecture { }

    public static class IGetSystemExtensions
    {
        public static T GetSystem<T>(this IGetSystem self) where T : ISystem
        {
            return self.GetArchitecture().GetSystem<T>();
        }
    }
}