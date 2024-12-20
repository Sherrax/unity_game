using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using TMPro;
using System.Collections;

public class SubtitleController : MonoBehaviour
{
    public CanvasGroup canvasGroup; // Grupa Canvas do efektu fade
    public TextMeshProUGUI subtitleText; // Obiekt tekstowy (TextMeshPro)
    public float fadeDuration = 1f; // Czas fade-in i fade-out
    public float displayDuration = 2f; // Czas wyświetlania napisu

    private Coroutine fadeCoroutine;

    // Funkcja wyświetlająca tekst z fade-in i fade-out
    public void ShowSubtitle(string text)
    {
        // Jeśli jest aktywna inna animacja, przerywamy ją
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        // Ustaw nowy tekst
        subtitleText.text = text;

        // Rozpocznij animację
        fadeCoroutine = StartCoroutine(PlaySubtitle());
    }

    // Korutyna do efektu fade-in i fade-out
    private IEnumerator PlaySubtitle()
    {
        // Fade-in
        yield return Fade(0, 1, fadeDuration);

        // Wyświetlanie tekstu
        yield return new WaitForSeconds(displayDuration);

        // Fade-out
        yield return Fade(1, 0, fadeDuration);
    }

    // Funkcja fade z interpolacją Alpha
    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
    }
}
