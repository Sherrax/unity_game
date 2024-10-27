using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public Transform headTransform; // Referencja do transformacji g�owy lub oczu modelu
    public Camera mainCamera;       // Kamera g��wna (przypisana w Unity)

    void Start()
    {
        // Przypisanie g��wnej kamery, je�li nie jest przypisana
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        // Uzyskaj pozycj� kursora myszy w przestrzeni ekranu
        Vector3 mousePosition = Input.mousePosition;

        // Przekonwertuj pozycj� kursora z przestrzeni ekranu do przestrzeni �wiata
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mainCamera.nearClipPlane + 1f));

        // Oblicz kierunek z g�owy do pozycji kursora
        Vector3 direction = worldPosition - headTransform.position;

        // Obr�� g�ow�/oczy w kierunku kursora, zachowuj�c oryginaln� orientacj� osi Y
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        headTransform.rotation = Quaternion.Slerp(headTransform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
