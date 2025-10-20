// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //


using System;
using System.Collections;
using UnityEngine;

namespace RCFramework.Tools
{
    public static class MonoBehaviourExtensions
    {
        public static T DelayedExecution<T>(this T monoBehaviour, float delay, Action callback) where T : MonoBehaviour
        {
            monoBehaviour.StartCoroutine(Execute(delay, callback));
            return monoBehaviour;
        }

        public static T DelayedUntil<T>(this T monoBehaviour, Func<bool> condition, Action callback, bool expectedResult = true) where T : MonoBehaviour
        {
            if (condition != null)
            {
                monoBehaviour.StartCoroutine(WaitForCondition(condition, callback, expectedResult));
            }
            return monoBehaviour;
        }

        public static T DelayedUntilNextFrame<T>(this T monoBehaviour, Action callback) where T : MonoBehaviour
        {
            monoBehaviour.StartCoroutine(ExecuteAfterFrame(callback));
            return monoBehaviour;
        }

        public static T RepeatWhile<T>(this T monoBehaviour, Func<bool> condition, float interval, Action callback, bool expectedResult = true) where T : MonoBehaviour
        {
            if (condition != null)
            {
                monoBehaviour.StartCoroutine(RepeatWhileCoroutine(condition, interval, callback, expectedResult));
            }

            return monoBehaviour;
        }

        private static IEnumerator Execute(float delay, Action callback)
        {
            yield return new WaitForSeconds(delay);
            callback?.Invoke();
        }

        private static IEnumerator ExecuteAfterFrame(Action callback)
        {
            yield return null;
            callback?.Invoke();
        }

        private static IEnumerator WaitForCondition(Func<bool> condition, Action callback, bool expectedResult)
        {
            yield return new WaitUntil(() => condition() == expectedResult);
            callback?.Invoke();
        }

        private static IEnumerator RepeatWhileCoroutine(Func<bool> condition, float interval, Action callback, bool expectedResult)
        {
            while (condition() == expectedResult)
            {
                yield return new WaitForSeconds(interval);
                callback?.Invoke();
            }
        }
    }
}