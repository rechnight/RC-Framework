// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using RCFramework.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RCFramework.Tools
{
    public class LoadingOverlay : ControllerBase, IProgress<float>
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Image _loadingBar;
        [SerializeField] private float _fadeDuration = 0.5f;
        [SerializeField] private float _fillSpeed = 0.5f;

        [Inject] private readonly SceneLoader _sceneLoader;

        private float _targetProgress;
        private bool _isLoading;

        private void Start()
        {
            _sceneLoader.SetOverlay(this);
        }

        private void Update()
        {
            if (!_isLoading || _loadingBar == null)
                return;

            float currentFillAmount = _loadingBar.fillAmount;
            float progressDifference = Mathf.Abs(currentFillAmount - _targetProgress);

            float dynamicFillSpeed = progressDifference * _fillSpeed;

            _loadingBar.fillAmount = Mathf.Lerp(currentFillAmount, _targetProgress, Time.deltaTime * dynamicFillSpeed);
        }

        public async Awaitable FadeIn()
        {
            _isLoading = true;

            if (_loadingBar != null)
            {
                _loadingBar.fillAmount = 0f;
            }

            _targetProgress = 1f;
            await FadeCanvasAlpha(1f);
        }

        public async Awaitable FadeOut()
        {
            await FadeCanvasAlpha(0f);
            _isLoading = false;
        }

        public void Report(float value)
        {
            _targetProgress = Mathf.Max(value, _targetProgress);
        }

        private async Awaitable FadeCanvasAlpha(float targetAlpha)
        {
            float startAlpha = _canvasGroup.alpha;
            float elapsedTime = 0f;

            while (elapsedTime < _fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float time = Mathf.Clamp01(elapsedTime / _fadeDuration);
                _canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time);
                await Awaitable.NextFrameAsync();
            }

            _canvasGroup.alpha = targetAlpha;
        }
    }
}