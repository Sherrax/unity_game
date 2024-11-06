using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using UnityEngine;
using System.Collections;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    public CanvasGroup canvasGroup; // Pod��cz CanvasGroup elementu UI
    public float defaultFadeDuration = 1f; // Domy�lny czas trwania fade-in/out
    public float defaultDelayBetweenFade = 1f; // Domy�lne op�nienie pomi�dzy fade-out i fade-in

    private void Awake()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    // Fade-in z mo�liwo�ci� ustawienia czasu trwania
    public void FadeIn(float duration = -1)
    {
        StartCoroutine(FadeCanvasGroup(0, 1, duration < 0 ? defaultFadeDuration : duration));
    }

    // Fade-out z mo�liwo�ci� ustawienia czasu trwania
    public void FadeOut(float duration = -1)
    {
        StartCoroutine(FadeCanvasGroup(1, 0, duration < 0 ? defaultFadeDuration : duration));
    }

    // Sekwencja Fade-out, op�nienie, Fade-in z konfigurowalnym czasem dla ka�dej fazy
    public void FadeInFadeOut(float fadeOutDuration = -1, float fadeInDuration = -1, float delayBetween = -1)
    {
        StartCoroutine(FadeInFadeOutSequence(
            fadeOutDuration < 0 ? defaultFadeDuration : fadeOutDuration,
            fadeInDuration < 0 ? defaultFadeDuration : fadeInDuration,
            delayBetween < 0 ? defaultDelayBetweenFade : delayBetween
        ));
    }

    private IEnumerator FadeInFadeOutSequence(float fadeOutDuration, float fadeInDuration, float delayBetween)
    {
        // Fade-out
        yield return StartCoroutine(FadeCanvasGroup(1, 0, fadeOutDuration));

        // Opcjonalne op�nienie
        yield return new WaitForSeconds(delayBetween);

        // Fade-in
        yield return StartCoroutine(FadeCanvasGroup(0, 1, fadeInDuration));
    }

    private IEnumerator FadeCanvasGroup(float start, float end, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, elapsed / duration);
            yield return null;
        }

        canvasGroup.alpha = end; // Ustawienie ostatecznej warto�ci przezroczysto�ci
    }
}
