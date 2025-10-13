// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Core
{
    [AttributeUsage(AttributeTargets.Field)]
    public class SelfAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Field)]
    public class ChildrenAttribute : Attribute
    {
        public bool IncludeInactive { get; }

        public ChildrenAttribute(bool includeInactive = true)
        {
            IncludeInactive = includeInactive;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ParentAttribute : Attribute
    {
        public bool IncludeInactive { get; }

        public ParentAttribute(bool includeInactive = true)
        {
            IncludeInactive = includeInactive;
        }
    }
}