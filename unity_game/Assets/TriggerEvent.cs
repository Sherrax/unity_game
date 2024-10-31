using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.Events; // Importujemy przestrze� nazw dla event�w

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent onPlayerEnter; // Event wywo�ywany przy wej�ciu gracza

    // Metoda wywo�ywana przy wej�ciu gracza do triggera
    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzenie, czy obiekt, kt�ry wszed� w stref�, jest graczem
        if (other.CompareTag("Player")) // Upewnij si�, �e obiekt gracza ma tag "Player"
        {
            onPlayerEnter.Invoke(); // Wywo�anie eventu
        }
    }
}
