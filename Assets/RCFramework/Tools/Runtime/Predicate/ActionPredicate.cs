// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Tools
{
    public class ActionPredicate: IPredicate
    {
        private bool _flag;

        public ActionPredicate(ref Action eventReaction)
        {
            eventReaction += () => { _flag = true; };
        }

        public bool Evaluate()
        {
            bool result = _flag;
            _flag = false;
            return result;
        }
    }
}