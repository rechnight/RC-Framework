// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Core
{
    public abstract class ControllerBase : MonoBehaviour, IController
    {
        private readonly ReferenceInjector _injector = new();

        protected virtual void Awake()
        {
            this.InjectDependency(this);
            _injector.Inject(this);
        }
    }
}
