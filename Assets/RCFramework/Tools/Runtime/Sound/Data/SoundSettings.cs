// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using UnityEngine;

namespace RCFramework.Tools
{
    [Serializable]
    public class SoundSettings
    {
        [Header("General")]
        [SerializeField] private bool _loop = false;
        [SerializeField] private PriorityLevel _priority = PriorityLevel.Standard;

        [Header("Volume")]
        [SerializeField, Range(0f, 1f)] private float _maxVolume = 1f;
        [SerializeField, Range(0f, 1f)] private float _minVolume = 1f;
        
        [Header("Pitch")]
        [SerializeField, Range(-3f, 3f)] private float _maxPitch = 1f;
        [SerializeField, Range(-3f, 3f)] private float _minPitch = 1f;

        [Header("Spatialisation")]
        [SerializeField, Range(-1f, 1f)] private float _panStereo = 0f;
        [SerializeField, Range(0f, 1f)] private float _spatialBlend = 0f;
        [SerializeField, Range(0f, 5f)] private float _dopplerLevel = 1f;
        [SerializeField, Range(0, 360)] private int _spread = 0;
        [SerializeField] private AudioRolloffMode _rolloffMode = AudioRolloffMode.Logarithmic;
        [SerializeField, Range(0.01f, 5f)] private float _minDistance = 0.1f;
        [SerializeField, Range(5f, 100f)] private float _maxDistance = 50f;

        [Header("Effects")]
        [SerializeField] private bool _bypassEffects = false;
        [SerializeField] private bool _bypassListenerEffects = false;
        [SerializeField] private bool _bypassReverbZones = false;
        [SerializeField, Range(0f, 1.1f)] private float _reverbZoneMix = 1f;

        [Header("Ignores")]
        [SerializeField] private bool _ignoreListenerVolume = false;
        [SerializeField] private bool _ignoreListenerPause = false;

        private enum PriorityLevel { Highest = 0, High = 64, Standard = 128, Low = 194, VeryLow = 256, }

        public void Apply(AudioSource audioSource)
        {
            audioSource.loop = _loop;
            audioSource.bypassEffects = _bypassEffects;
            audioSource.bypassListenerEffects = _bypassListenerEffects;
            audioSource.bypassReverbZones = _bypassReverbZones;
            audioSource.priority = (int)_priority;
            audioSource.volume = UnityEngine.Random.Range(_maxVolume, _minVolume);
            audioSource.pitch = UnityEngine.Random.Range(_maxPitch, _minPitch);
            audioSource.panStereo = _panStereo;
            audioSource.spatialBlend = _spatialBlend;
            audioSource.reverbZoneMix = _reverbZoneMix;
            audioSource.dopplerLevel = _dopplerLevel;
            audioSource.spread = _spread;
            audioSource.rolloffMode = _rolloffMode;
            audioSource.minDistance = _minDistance;
            audioSource.maxDistance = _maxDistance;
            audioSource.ignoreListenerVolume = _ignoreListenerVolume;
            audioSource.ignoreListenerPause = _ignoreListenerPause;
        }
    }
}