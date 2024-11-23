using UnityEngine;
using TMPro;  // Jeœli u¿ywasz TextMeshPro, zaimportuj ten namespace
using UnityEngine.UI;  // Jeœli u¿ywasz standardowego Text

public class TextObject : MonoBehaviour
{
    public string text;  // Tekst, który ma byæ wyœwietlany
    public TextMeshProUGUI textMeshProUGUI;  // Komponent TextMeshProUGUI
    public Text textUI;  // Komponent Text (standardowy Unity UI)

    private void Awake()
    {
        // Domyœlnie ukrywamy tekst
        HideText();
    }

    // Metoda wyœwietlaj¹ca tekst
    public void ShowText()
    {
        if (textMeshProUGUI != null)
        {
            textMeshProUGUI.text = text;
            textMeshProUGUI.gameObject.SetActive(true);  // Ustawiamy widocznoœæ na true
        }
        else if (textUI != null)
        {
            textUI.text = text;
            textUI.gameObject.SetActive(true);  // Ustawiamy widocznoœæ na true
        }
    }

    // Metoda ukrywaj¹ca tekst
    public void HideText()
    {
        if (textMeshProUGUI != null)
        {
            textMeshProUGUI.gameObject.SetActive(false);  // Ustawiamy widocznoœæ na false
        }
        else if (textUI != null)
        {
            textUI.gameObject.SetActive(false);  // Ustawiamy widocznoœæ na false
        }
    }
}
