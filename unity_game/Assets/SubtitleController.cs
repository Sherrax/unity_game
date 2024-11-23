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
    public float displayDuration = 2f; // Czas wy�wietlania napisu

    private Coroutine fadeCoroutine;

    // Funkcja wy�wietlaj�ca tekst z fade-in i fade-out
    public void ShowSubtitle(string text)
    {
        // Je�li jest aktywna inna animacja, przerywamy j�
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        // Ustaw nowy tekst
        subtitleText.text = text;

        // Rozpocznij animacj�
        fadeCoroutine = StartCoroutine(PlaySubtitle());
    }

    // Korutyna do efektu fade-in i fade-out
    private IEnumerator PlaySubtitle()
    {
        // Fade-in
        yield return Fade(0, 1, fadeDuration);

        // Wy�wietlanie tekstu
        yield return new WaitForSeconds(displayDuration);

        // Fade-out
        yield return Fade(1, 0, fadeDuration);
    }

    // Funkcja fade z interpolacj� Alpha
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
