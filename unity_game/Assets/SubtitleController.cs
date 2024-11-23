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
    public float displayDuration = 2f; // Czas wyœwietlania napisu

    private Coroutine fadeCoroutine;

    // Funkcja wyœwietlaj¹ca tekst z fade-in i fade-out
    public void ShowSubtitle(string text)
    {
        // Jeœli jest aktywna inna animacja, przerywamy j¹
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        // Ustaw nowy tekst
        subtitleText.text = text;

        // Rozpocznij animacjê
        fadeCoroutine = StartCoroutine(PlaySubtitle());
    }

    // Korutyna do efektu fade-in i fade-out
    private IEnumerator PlaySubtitle()
    {
        // Fade-in
        yield return Fade(0, 1, fadeDuration);

        // Wyœwietlanie tekstu
        yield return new WaitForSeconds(displayDuration);

        // Fade-out
        yield return Fade(1, 0, fadeDuration);
    }

    // Funkcja fade z interpolacj¹ Alpha
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
