// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface IRegisterModel : IGetArchitecture 
    {
        void TrackModel(IModel model);
    }

    public static class IRegisterModelExtension
    {
        public static void RegisterModel<T>(this IRegisterModel self, T model) where T : class, IModel
        {
            self.GetArchitecture().RegisterModel(model);
            self.TrackModel(model);
        }

        public static void UnregisterModel<T>(this IRegisterModel self, T model) where T : class, IModel
        {
            self.GetArchitecture().UnregisterModel(model);
        }
    }
}