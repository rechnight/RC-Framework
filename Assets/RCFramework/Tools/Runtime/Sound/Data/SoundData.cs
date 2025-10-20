// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using UnityEngine;
using UnityEngine.Audio;

namespace RCFramework.Tools
{
    [Serializable]
    public class SoundData : ISoundData
    {
        [SerializeField] private AudioResource _audioResource;
        [SerializeField] private SoundChannel _channel = SoundChannel.SFX;
        [SerializeField] private SoundSettings _soundSettings;

        public AudioResource Resource => _audioResource;
        public SoundChannel Channel => _channel;
        public SoundSettings Settings => _soundSettings;

        public SoundData(AudioResource audioResource)
        {
            _audioResource = audioResource;
        }
    }
}