using UnityEngine;
using UnityEngine.Video;

public class VideoOnMaterial : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Video Player przypisany do obiektu
    public Renderer objectRenderer;  // Renderer obiektu, na którym jest wiêcej ni¿ jeden materia³
    public int materialIndex = 0;   // Indeks materia³u, na którym ma byæ wyœwietlane wideo

    void Start()
    {
        // Sprawdzamy, czy indeks materia³u jest poprawny
        if (materialIndex < objectRenderer.materials.Length)
        {
            // Pobieramy materia³y z rendereru obiektu
            Material[] materials = objectRenderer.materials;

            // Ustawiamy VideoPlayer, aby renderowa³ wideo na odpowiednim materiale
            videoPlayer.targetMaterialRenderer = objectRenderer;  // Okreœlamy renderer, na którym bêdzie odtwarzane wideo
            videoPlayer.targetMaterialProperty = "_MainTex";      // Okreœlamy, ¿e wideo ma byæ na g³ównej teksturze
            videoPlayer.targetMaterialRenderer.materials[materialIndex] = videoPlayer.targetMaterialRenderer.materials[materialIndex];  // Przypisujemy materia³ do odpowiedniego slotu

            // Rozpoczynamy odtwarzanie wideo
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("Nieprawid³owy indeks materia³u!");
        }
    }
}
