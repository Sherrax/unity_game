using UnityEngine;
using TMPro; // U�ywamy TextMeshPro
using UnityEngine.Events; // Przestrze� nazw dla event�w
using System.Collections.Generic; // Przestrze� nazw dla list

public class MissionObject : MonoBehaviour
{
    public enum State { Aktywny, Ukonczony } // Enum dla stan�w
    public State currentState;

    public TMP_Text messageText; // Przypisanie elementu UI TextMeshPro
    public string activeMessage = "Obiekt jest aktywny!"; // Wiadomo��, kt�r� mo�na ustawi� w edytorze
    public List<UnityEvent> onCompleteEvents; // Lista event�w do wywo�ania w stanie uko�czonym

    void Start()
    {
        UpdateState(State.Aktywny); // Ustawienie pocz�tkowego stanu
    }

    void UpdateState(State newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case State.Aktywny:
                messageText.text = activeMessage; // Wy�wietlanie aktywnej wiadomo�ci
                break;
            case State.Ukonczony:
                messageText.text = ""; // Ukrycie wiadomo�ci
                foreach (var unityEvent in onCompleteEvents)
                {
                    unityEvent.Invoke(); // Wywo�anie event�w
                }
                gameObject.SetActive(false); // Dezaktywacja obiektu
                break;
        }
    }

    // Publiczna metoda, kt�ra pozwala na zewn�trzne wywo�anie zmiany stanu na uko�czony
    public void Complete()
    {
        UpdateState(State.Ukonczony); // Przej�cie do stanu uko�czonego
    }

    // Publiczna metoda do aktywacji obiektu
    public void Activate()
    {
        UpdateState(State.Aktywny); // Przej�cie do stanu aktywnego
    }
}

