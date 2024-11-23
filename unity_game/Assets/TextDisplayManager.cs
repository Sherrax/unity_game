using System.Collections.Generic;
using UnityEngine;

public class TextDisplayManager : MonoBehaviour
{
    public List<TextObject> textObjects = new List<TextObject>();  // Lista wszystkich obiekt�w tekstowych
    private TextObject activeTextObject;  // Przechowuje referencj� do aktywnego obiektu tekstowego

    // Funkcja ustawiaj�ca aktywny obiekt tekstowy
    public void SetActiveTextObject(TextObject newTextObject)
    {
        // Je�eli aktywny obiekt jest r�ny od null, ukrywamy jego tekst
        if (activeTextObject != null)
        {
            activeTextObject.HideText();
        }

        // Ustawiamy nowy obiekt jako aktywny
        activeTextObject = newTextObject;
        activeTextObject.ShowText();  // Pokazujemy tekst nowego aktywnego obiektu
    }

    // Funkcja wy�wietlaj�ca tekst aktywnego obiektu (mo�esz po��czy� j� z UI, aby wy�wietla� tekst na ekranie)
    public string GetActiveText()
    {
        if (activeTextObject != null)
        {
            return activeTextObject.text;
        }
        return "";
    }
}