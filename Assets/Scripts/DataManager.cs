using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string selectedPlayer;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            Instance.selectedPlayer = "Chicken";
            DontDestroyOnLoad(Instance);
        }
    }
}
