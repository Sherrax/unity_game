using UnityEngine;
using TMPro;  // Je�li u�ywasz TextMeshPro, zaimportuj ten namespace
using UnityEngine.UI;  // Je�li u�ywasz standardowego Text

public class TextObject : MonoBehaviour
{
    public string text;  // Tekst, kt�ry ma by� wy�wietlany
    public TextMeshProUGUI textMeshProUGUI;  // Komponent TextMeshProUGUI
    public Text textUI;  // Komponent Text (standardowy Unity UI)

    private void Awake()
    {
        // Domy�lnie ukrywamy tekst
        HideText();
    }

    // Metoda wy�wietlaj�ca tekst
    public void ShowText()
    {
        if (textMeshProUGUI != null)
        {
            textMeshProUGUI.text = text;
            textMeshProUGUI.gameObject.SetActive(true);  // Ustawiamy widoczno�� na true
        }
        else if (textUI != null)
        {
            textUI.text = text;
            textUI.gameObject.SetActive(true);  // Ustawiamy widoczno�� na true
        }
    }

    // Metoda ukrywaj�ca tekst
    public void HideText()
    {
        if (textMeshProUGUI != null)
        {
            textMeshProUGUI.gameObject.SetActive(false);  // Ustawiamy widoczno�� na false
        }
        else if (textUI != null)
        {
            textUI.gameObject.SetActive(false);  // Ustawiamy widoczno�� na false
        }
    }
}
