using UnityEngine;

public class LookAtMouseTarget : MonoBehaviour
{
    public Camera mainCamera;
    public Transform lookTarget;       // Pusty obiekt LookTarget
    public BoxCollider trackingArea;   // Collider okre�laj�cy obszar �ledzenia
    public float followSpeed = 5f;     // Pr�dko�� interpolacji
    public Vector3 defaultPosition;    // Domy�lna pozycja LookTarget, gdy kursor jest poza obszarem

    private bool isInsideArea = false; // Flaga sprawdzaj�ca, czy kursor jest w colliderze

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        // Zapisz domy�ln� pozycj� LookTarget
        defaultPosition = lookTarget.position;
    }

    void Update()
    {
        // Pobierz pozycj� kursora w przestrzeni �wiata
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mainCamera.nearClipPlane + 2f));

        // Sprawd�, czy kursor znajduje si� wewn�trz Box Collidera
        if (IsWithinBounds(worldPosition))
        {
            // Aktualizuj pozycj� LookTarget, aby �ledzi� myszk�
            lookTarget.position = Vector3.Lerp(lookTarget.position, worldPosition, Time.deltaTime * followSpeed);
            isInsideArea = true;
        }
        else if (isInsideArea)
        {
            // Gdy kursor opu�ci obszar, wr�� do domy�lnej pozycji
            lookTarget.position = Vector3.Lerp(lookTarget.position, defaultPosition, Time.deltaTime * followSpeed);
            isInsideArea = false;
        }
    }

    // Funkcja sprawdzaj�ca, czy punkt znajduje si� wewn�trz Box Collidera
    private bool IsWithinBounds(Vector3 point)
    {
        return trackingArea.bounds.Contains(point);
    }
}

