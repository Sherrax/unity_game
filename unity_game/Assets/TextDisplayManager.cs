using System.Collections.Generic;
using UnityEngine;

public class TextDisplayManager : MonoBehaviour
{
    public List<TextObject> textObjects = new List<TextObject>();  // Lista wszystkich obiektów tekstowych
    private TextObject activeTextObject;  // Przechowuje referencjê do aktywnego obiektu tekstowego

    // Funkcja ustawiaj¹ca aktywny obiekt tekstowy
    public void SetActiveTextObject(TextObject newTextObject)
    {
        // Je¿eli aktywny obiekt jest ró¿ny od null, ukrywamy jego tekst
        if (activeTextObject != null)
        {
            activeTextObject.HideText();
        }

        // Ustawiamy nowy obiekt jako aktywny
        activeTextObject = newTextObject;
        activeTextObject.ShowText();  // Pokazujemy tekst nowego aktywnego obiektu
    }

    // Funkcja wyœwietlaj¹ca tekst aktywnego obiektu (mo¿esz po³¹czyæ j¹ z UI, aby wyœwietlaæ tekst na ekranie)
    public string GetActiveText()
    {
        if (activeTextObject != null)
        {
            return activeTextObject.text;
        }
        return "";
    }
}