using UnityEngine;
using UnityEngine.Video;

public class VideoOnMaterial : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Video Player przypisany do obiektu
    public Renderer objectRenderer;  // Renderer obiektu, na kt�rym jest wi�cej ni� jeden materia�
    public int materialIndex = 0;   // Indeks materia�u, na kt�rym ma by� wy�wietlane wideo

    void Start()
    {
        // Sprawdzamy, czy indeks materia�u jest poprawny
        if (materialIndex < objectRenderer.materials.Length)
        {
            // Pobieramy materia�y z rendereru obiektu
            Material[] materials = objectRenderer.materials;

            // Ustawiamy VideoPlayer, aby renderowa� wideo na odpowiednim materiale
            videoPlayer.targetMaterialRenderer = objectRenderer;  // Okre�lamy renderer, na kt�rym b�dzie odtwarzane wideo
            videoPlayer.targetMaterialProperty = "_MainTex";      // Okre�lamy, �e wideo ma by� na g��wnej teksturze
            videoPlayer.targetMaterialRenderer.materials[materialIndex] = videoPlayer.targetMaterialRenderer.materials[materialIndex];  // Przypisujemy materia� do odpowiedniego slotu

            // Rozpoczynamy odtwarzanie wideo
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("Nieprawid�owy indeks materia�u!");
        }
    }
}
