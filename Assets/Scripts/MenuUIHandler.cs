using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public GameObject selectedPlayer;
    public void StartGame() {
        SceneManager.LoadScene("Main");
    }
}
