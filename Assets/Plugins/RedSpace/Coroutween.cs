using System;
using System.Collections;
using UnityEngine;

public class Coroutween
{
    public static Color spriteTransparent = new Color(1f, 1f, 1f, 0f);
    public static Color spriteOpaque = new Color(1f, 1f, 1f, 1f);

    public static IEnumerator FrameDelay(Action callback)
    {
        yield return new WaitForEndOfFrame();
        if (callback != null)
            callback();
    }

    public static IEnumerator Delay(float delay, Action onComplete)
    {
        yield return new WaitForSecondsRealtime(delay);
        if (onComplete != null)
            onComplete();
    }

    public static IEnumerator Animate(float duration, Action<float> onUpdate, Func<double,double,double,double,double> easing = null, float delay = 0f) {

        if (easing == null)
            easing = Easing.Linear;

        if (delay > 0f)
            yield return new WaitForSecondsRealtime(delay);

        float startTime = Time.unscaledTime;

        onUpdate((float)easing(0, 0, 1, 1));

        while (Time.unscaledTime - startTime <= duration)
        {
            float t = (Time.unscaledTime - startTime) / duration;
            t = (float)easing(t, 0, 1, 1);
            onUpdate(t);
            yield return null;
        }

        onUpdate((float)easing(1, 0, 1, 1));
    }

    public static IEnumerator Animate(float duration, Action<float> onUpdate, AnimationCurve curve, float delay = 0f)
    {

        if (delay > 0f)
            yield return new WaitForSecondsRealtime(delay);

        float startTime = Time.unscaledTime;

        onUpdate(curve.Evaluate(0f));

        while (Time.unscaledTime - startTime <= duration)
        {
            float t = (Time.unscaledTime - startTime) / duration;
            t = curve.Evaluate(t);
            onUpdate(t);
            yield return null;
        }

        onUpdate(curve.Evaluate(1f));
    }
}
