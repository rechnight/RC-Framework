// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface IRegisterSystem : IGetArchitecture 
    {
        void TrackSystem(ISystem system);
    }

    public static class IRegisterSystemExtension
    {
        public static void RegisterSystem<T>(this IRegisterSystem self, T system) where T : class, ISystem
        {
            self.GetArchitecture().RegisterSystem(system);
            self.TrackSystem(system);
        }

        public static void UnregisterSystem<T>(this IRegisterSystem self, T system) where T : class, ISystem
        {
            self.GetArchitecture().UnregisterSystem(system);
        }
    }
}