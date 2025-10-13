// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public abstract class CommandBase : ICommand
    {
        void ICommand.Execute()
        {
            this.InjectDependency(this);
            Execute();
        }

        protected abstract void Execute();
    }

    public abstract class CommandBase<T> : ICommand<T>
    {
        T ICommand<T>.Execute()
        {
            this.InjectDependency(this);
            return Execute();
        }
        
        protected abstract T Execute();
    }
}