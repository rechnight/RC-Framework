// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Pool;

namespace RCFramework.Tools
{
    public enum SoundChannel { Master, Music, SFX, UI }

    public class SoundManager : MonoBehaviour
    {
        [Header("Sound Emitter Pool")]
        [SerializeField] private int _defaultCapacity = 10;
        [SerializeField] private int _maxPoolSize = 100;

        [Header("Audio Mixer Control")]
        [SerializeField] private AudioMixer _targetAudioMixer;

        [Header("Master")]
        [SerializeField] private AudioMixerGroup _masterAudioMixerGroup;
        [SerializeField] private string _masterVolumeParameter = "MasterVolume";
        [SerializeField] [Range(0.0001f, 1f)] private float _masterVolume = 1f;

        [Header("Music")]
        [SerializeField] private AudioMixerGroup _musicAudioMixerGroup;
        [SerializeField] private string _musicVolumeParameter = "MusicVolume";
        [SerializeField] [Range(0.0001f, 1f)] private float _musicVolume = 1f;

        [Header("SFX")]
        [SerializeField] private AudioMixerGroup _sFXAudioMixerGroup;
        [SerializeField] private string _sFXVolumeParameter = "SFXVolume";
        [SerializeField] [Range(0.0001f, 1f)] private float _sFXVolume = 1f;

        [Header("UI")]
        [SerializeField] private AudioMixerGroup _uIAudioMixerGroup;
        [SerializeField] private string _uIVolumeParameter = "UIVolume";
        [SerializeField] [Range(0.0001f, 1f)] private float _uIVolume = 1f;

        private IObjectPool<SoundEmitter> _soundEmitterPool;
        private readonly List<SoundEmitter> _activeSoundEmitters = new();

        private void OnValidate()
        {
            if (Application.isPlaying)
            {
                SetChannelVolume(SoundChannel.Master, _masterVolume);
                SetChannelVolume(SoundChannel.Music, _musicVolume);
                SetChannelVolume(SoundChannel.SFX, _sFXVolume);
                SetChannelVolume(SoundChannel.UI, _uIVolume);
            }
        }

        private void Awake()
        {
            InitializePool();
        }

        public SoundEmitter CreateSound(ISoundData soundData)
        {
            SoundEmitter soundEmitter = _soundEmitterPool.Get();
            soundEmitter.Initialize(soundData, GetAudioMixerGroup(soundData.Channel));

            return soundEmitter;
        }

        public void SetChannelVolume(SoundChannel channel, float volume)
        {
            if (volume <= 0f)
            {
                volume = 0.0001f;
            }

            switch (channel)
            {
                case SoundChannel.Master:
                    _targetAudioMixer.SetFloat(_masterVolumeParameter, NormalizedToMixerVolume(volume));
                    _masterVolume = volume;
                    break;
                case SoundChannel.Music:
                    _targetAudioMixer.SetFloat(_musicVolumeParameter, NormalizedToMixerVolume(volume));
                    _musicVolume = volume;
                    break;
                case SoundChannel.SFX:
                    _targetAudioMixer.SetFloat(_sFXVolumeParameter, NormalizedToMixerVolume(volume));
                    _sFXVolume = volume;
                    break;
                case SoundChannel.UI:
                    _targetAudioMixer.SetFloat(_uIVolumeParameter, NormalizedToMixerVolume(volume));
                    _uIVolume = volume;
                    break;
            }
        }

        public float GetChannelVolume(SoundChannel channel)
        {
            float volume = 1f;
            switch (channel)
            {
                case SoundChannel.Master:
                    _targetAudioMixer.GetFloat(_masterVolumeParameter, out volume);
                    break;
                case SoundChannel.Music:
                    _targetAudioMixer.GetFloat(_musicVolumeParameter, out volume);
                    break;
                case SoundChannel.SFX:
                    _targetAudioMixer.GetFloat(_sFXVolumeParameter, out volume);
                    break;
                case SoundChannel.UI:
                    _targetAudioMixer.GetFloat(_uIVolumeParameter, out volume);
                    break;
            }

            return MixerVolumeToNormalized(volume);
        }

        private AudioMixerGroup GetAudioMixerGroup(SoundChannel channel)
        {
            return channel switch
            {
                SoundChannel.Master => _masterAudioMixerGroup,
                SoundChannel.Music => _musicAudioMixerGroup,
                SoundChannel.SFX => _sFXAudioMixerGroup,
                SoundChannel.UI => _uIAudioMixerGroup,
                _ => _masterAudioMixerGroup
            };
        }

        private float NormalizedToMixerVolume(float normalizedVolume) => Mathf.Log10(normalizedVolume) * 20;

        private float MixerVolumeToNormalized(float mixerVolume) => (float)Math.Pow(10, (mixerVolume / 20));

        private void OnSoundFinishedPlaying(SoundEmitter soundEmitter) => _soundEmitterPool.Release(soundEmitter);
        
        private void InitializePool()
        {
            _soundEmitterPool = new ObjectPool<SoundEmitter>(CreateSoundEmitter, OnGetFromPool, OnReturnToPool, OnDestroyPoolObject,
                true, _defaultCapacity, _maxPoolSize);
        }

        private SoundEmitter CreateSoundEmitter()
        {
            var soundEmitter = new GameObject("Sound Emitter").AddComponent<SoundEmitter>();
            soundEmitter.transform.SetParent(transform);
            soundEmitter.gameObject.SetActive(false);
            return soundEmitter;
        }

        private void OnGetFromPool(SoundEmitter soundEmitter)
        {
            soundEmitter.gameObject.SetActive(true);
            _activeSoundEmitters.Add(soundEmitter);
            soundEmitter.SoundFinishedPlaying += OnSoundFinishedPlaying;
        }

        private void OnReturnToPool(SoundEmitter soundEmitter)
        {
            soundEmitter.gameObject.SetActive(false);
            _activeSoundEmitters.Remove(soundEmitter);
            soundEmitter.SoundFinishedPlaying -= OnSoundFinishedPlaying;
        }

        private void OnDestroyPoolObject(SoundEmitter soundEmitter)
        {
            if (soundEmitter != null)
            {
                Destroy(soundEmitter.gameObject);
            }
        }
    }
}