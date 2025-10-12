// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface ILoadArchitecture : IGetArchitecture { }

    public static class ILoadArchitectureExtension
    {
        public static void LoadArchitecture(this ILoadArchitecture self)
        {
            self.GetArchitecture().Load();
        }

        public static void UnloadArchitecture(this ILoadArchitecture self)
        {
            self.GetArchitecture().Unload();
        }
    }
}
