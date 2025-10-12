// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface IRegisterUtility : IGetArchitecture 
    {
        void TrackUtility(IUtility utility);
    }

    public static class IRegisterUtilityExtension
    {
        public static void RegisterUtility<T>(this IRegisterUtility self, T utility) where T : class, IUtility
        {
            self.GetArchitecture().RegisterUtility(utility);
            self.TrackUtility(utility);
        }

        public static void UnregisterUtility<T>(this IRegisterUtility self, T utility) where T : class, IUtility
        {
            self.GetArchitecture().UnregisterUtility(utility);
        }
    }
}
