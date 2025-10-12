// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface ISendCommand : IGetArchitecture { }

    public static class ISendCommandExtensions
    {
        public static void SendCommand(this ISendCommand self, ICommand command)
        {
            self.GetArchitecture().SendCommand(command);
        }

        public static T SendCommand<T>(this ISendCommand self, ICommand<T> command)
        {
            return self.GetArchitecture().SendCommand(command);
        }
    }
}
