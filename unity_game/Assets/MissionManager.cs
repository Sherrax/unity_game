using UnityEngine;
using System.Collections.Generic;

public class MissionManager : MonoBehaviour
{
    public List<MissionObject> missionObjects; // Lista obiekt�w misji
    private int currentMissionIndex = 0; // Indeks aktualnej misji

    void Start()
    {
        // Zbieranie wszystkich obiekt�w MissionObject, kt�re s� dzie�mi tego obiektu
        missionObjects = new List<MissionObject>(GetComponentsInChildren<MissionObject>());
       
    }


}
