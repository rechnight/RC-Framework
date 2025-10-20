// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using UnityEngine;
using UnityEngine.Audio;

namespace RCFramework.Tools
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEmitter : MonoBehaviour
    {
        private AudioSource _audioSource;

        public AudioClip Clip => _audioSource.clip;
        public bool IsPlaying => _audioSource.isPlaying;
        public bool IsLooping => _audioSource.loop;

        public Action<SoundEmitter> SoundFinishedPlaying;

        private void Awake()
        {
            _audioSource = gameObject.GetOrAddComponent<AudioSource>();
        }

        public void Initialize(ISoundData soundData, AudioMixerGroup audioMixerGroup)
        {
            _audioSource.resource = soundData.Resource;
            _audioSource.outputAudioMixerGroup = audioMixerGroup;
            soundData.Settings.Apply(_audioSource);
        }

        public SoundEmitter WithPosition(Vector3 position)
        {
            transform.position = position;
            return this;
        }

        public SoundEmitter SetVolume(float volume)
        {
            _audioSource.volume = volume;
            return this;
        }

        public SoundEmitter SetPitch(float pitch)
        {
            _audioSource.pitch = pitch;
            return this;
        }

        public SoundEmitter WithRandomVolume(float min, float max)
        {
            _audioSource.volume = UnityEngine.Random.Range(min, max);
            return this;
        }

        public SoundEmitter WithRandomPitch(float min, float max)
        {
            _audioSource.pitch = UnityEngine.Random.Range(min, max);
            return this;
        }

        public SoundEmitter Play()
        {
            PlayAsync();
            return this;
        }

        public SoundEmitter FadeIn(float duration)
        {
            float targetVolume = _audioSource.volume;
            _audioSource.volume = 0f;

            Play();
            _ = FadeVolume(targetVolume, duration);
            return this;
        }

        public async void FadeOut(float duration)
        {
            await FadeVolume(0, duration);
            Stop();
        }

        public void Pause() => _audioSource.Pause();

        public void Resume() => _audioSource.Play();

        public void Stop() => _audioSource.Stop();

        private async void PlayAsync()
        {
            _audioSource.Play();
            while (_audioSource.isPlaying)
            {
                await Awaitable.NextFrameAsync();
            }
            NotifyBeingDone();
        }

        private async Awaitable FadeVolume(float targetVolume, float duration)
        {
            float elapsedTime = 0f;
            float startVolume = _audioSource.volume;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                _audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / duration);
                await Awaitable.NextFrameAsync();
            }

            _audioSource.volume = targetVolume;
        }

        private void NotifyBeingDone()
        {
            SoundFinishedPlaying?.Invoke(this);
        }
    }
}