// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface IInjectDependency : IGetArchitecture { }

    public static class IInjectDependencyExtension
    {
        public static void InjectDependency(this IInjectDependency self, object obj)
        {
            self.GetArchitecture().InjectDependency(obj);
        }
    }
}
