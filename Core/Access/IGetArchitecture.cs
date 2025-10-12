// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface IGetArchitecture { }

    public static class IGetArchitectureExtensions
    {
        public static IArchitecture GetArchitecture(this IGetArchitecture self)
        {
            return Architecture.Instance;
        }
    }
}
