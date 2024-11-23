using UnityEngine;
using UnityEngine.UI; // Dodaj ten import, jeœli korzystasz z komponentu UI (Text)

public class SubtitleDisplay : MonoBehaviour
{
    public Text subtitleText; // Referencja do komponentu Text

    public void ShowSubtitle(string text)
    {
        subtitleText.text = text;
        subtitleText.enabled = true;
    }

    public void HideSubtitle()
    {
        subtitleText.enabled = false;
    }
}
