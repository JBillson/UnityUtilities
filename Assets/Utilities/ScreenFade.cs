using System;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace UnityUtilities.Assets.Utilities
{
    public class ScreenFade : MonoBehaviour
    {
        [Header("References")] public CanvasGroup fadeGroup;


        [Header("Fade Settings")] public float defaultFadeTime = 2f;
        public bool startWithFade = true;
        [ShowIf("startWithFade")] public float startFadeTime = 2f;


        private Coroutine _fadeInCoroutine;
        private Coroutine _fadeOutCoroutine;
        private Image _fadeImage;

        private void Awake()
        {
            _fadeImage = fadeGroup.GetComponentInChildren<Image>();
        }

        private void Start()
        {
            if (startWithFade)
            {
                fadeGroup.alpha = 1;
                FadeIn(startFadeTime);
            }
            else
            {
                fadeGroup.alpha = 0;
            }
        }

        public void FadeIn()
        {
            FadeIn(defaultFadeTime, _fadeImage.color);
        }

        public void FadeIn(float fadeTime)
        {
            FadeIn(fadeTime, _fadeImage.color);
        }

        public void FadeIn(float fadeTime, Color fadeColor, Action func = null)
        {
            _fadeImage.color = fadeColor;
            if (_fadeInCoroutine != null)
            {
                StopCoroutine(_fadeInCoroutine);
            }

            _fadeInCoroutine = StartCoroutine(UpdateFadeIn(fadeTime, func));
        }

        private IEnumerator UpdateFadeIn(float fadeTime, Action func)
        {
            var t = 0f;

            for (t = 0; t <= 1; t += Time.deltaTime / fadeTime)
            {
                fadeGroup.alpha = 1 - t;
                yield return null;
            }

            fadeGroup.alpha = 0;
            func?.Invoke();
        }

        public void FadeOut()
        {
            FadeOut(defaultFadeTime, _fadeImage.color);
        }

        public void FadeOut(float fadeTime)
        {
            FadeOut(fadeTime, _fadeImage.color);
        }

        public void FadeOut(float fadeTime, Color fadeColor, Action func = null)
        {
            _fadeImage.color = fadeColor;
            if (_fadeOutCoroutine != null)
            {
                StopCoroutine(_fadeOutCoroutine);
            }

            _fadeOutCoroutine = StartCoroutine(UpdateFadeOut(fadeTime, func));
        }

        private IEnumerator UpdateFadeOut(float fadeTime, Action func)
        {
            var t = 0f;

            for (t = 0; t <= 1; t += Time.deltaTime / fadeTime)
            {
                fadeGroup.alpha = t;
                yield return null;
            }

            fadeGroup.alpha = 1;
            func?.Invoke();
        }
    }
}