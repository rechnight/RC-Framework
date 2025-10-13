// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Collections.Generic;
using UnityEngine;

namespace RCFramework.Core
{
    [DefaultExecutionOrder(-1000)]
    [DisallowMultipleComponent]
    public abstract class BootstrapperBase : MonoBehaviour, IBootstrapper
    {
        private bool _hasBeenBootstrapped;

        private readonly HashSet<ISystem> _registeredSystems = new();
        private readonly HashSet<IModel> _registeredModels = new();
        private readonly HashSet<IUtility> _registeredUtilities = new();

        private void Awake()
        {
            if (_hasBeenBootstrapped)
                return;

            _hasBeenBootstrapped = true;
            Bootstrap();

            this.GetArchitecture().Load();
        }

        private void OnDestroy()
        {
            if (!_hasBeenBootstrapped)
                return;

            Shutdown();
            UnregisterInstances();
        }

        void IRegisterSystem.TrackSystem(ISystem system) => _registeredSystems.Add(system);
        void IRegisterModel.TrackModel(IModel model) => _registeredModels.Add(model);
        void IRegisterUtility.TrackUtility(IUtility utility) => _registeredUtilities.Add(utility);
        
        protected abstract void Bootstrap();
        protected virtual void Shutdown() { }

        private void UnregisterInstances()
        {
            foreach (var system in _registeredSystems)
                this.UnregisterSystem(system);

            foreach (var model in _registeredModels)
                this.UnregisterModel(model);

            foreach (var utility in _registeredUtilities)
                this.UnregisterUtility(utility);

            _registeredSystems.Clear();
            _registeredModels.Clear();
            _registeredUtilities.Clear();
        }
    }
}