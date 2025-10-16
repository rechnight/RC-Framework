// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface IGetUtility : IGetArchitecture { }

    public static class IGetUtilityExtensions
    {
        public static T GetUtility<T>(this IGetUtility self) where T : IUtility
        {
            return self.GetArchitecture().GetUtility<T>();
        }
    }

}
