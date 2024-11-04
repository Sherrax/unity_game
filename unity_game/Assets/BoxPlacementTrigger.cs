using UnityEngine;
using UnityEngine.Events;

public class BoxTrigger : MonoBehaviour
{
    // Referencja do konkretnego obiektu, na kt�ry pud�o ma reagowa�
    public GameObject specificTrigger; // Przypisz obiekt w Inspektorze

    // Event do wywo�ania, gdy pud�o trafi na konkretny trigger
    public UnityEvent onSpecificTriggerActivated;

    // Funkcja wywo�ywana automatycznie przez Unity, gdy obiekt wchodzi w trigger
    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzanie, czy obiekt, z kt�rym kolidujemy, jest tym konkretnym triggerem
        if (other.gameObject == specificTrigger) // Por�wnujemy z konkretnym obiektem
        {
            // Wywo�anie eventu, gdy pud�o wchodzi w obszar konkretnego triggera
            if (onSpecificTriggerActivated != null)
            {
                onSpecificTriggerActivated.Invoke();
            }
        }
    }
}
