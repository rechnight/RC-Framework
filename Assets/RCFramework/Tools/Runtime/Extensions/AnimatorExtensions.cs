// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Tools
{
    public static class AnimatorExtensions
    {
        public static async Awaitable WaitForAnimation(this Animator animator, string animationName)
        {
            if (animator == null || string.IsNullOrEmpty(animationName))
                return;

            while (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
            {
                await Awaitable.NextFrameAsync();
            }

            while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            {
                await Awaitable.NextFrameAsync();
            }
        }

        public static async Awaitable PlayAndWaitForAnimation(this Animator animator, string animationName)
        {
            if (animator == null || string.IsNullOrEmpty(animationName)) 
                return;

            animator.Play(animationName);

            while (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
            {
                await Awaitable.NextFrameAsync();
            }

            while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            {
                await Awaitable.NextFrameAsync();
            }
        }

        public static async void DestroyOnAnimationEnd(this Animator animator, string animationName)
        {
            if (animator == null || string.IsNullOrEmpty(animationName))
                return;

            while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            {
                await Awaitable.NextFrameAsync();
            }

            Object.Destroy(animator.gameObject);
        }
    }
}