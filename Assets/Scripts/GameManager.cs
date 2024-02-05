using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    
    private void Update() {
        scoreText.text = "Score: " + score;
        gameOverText.gameObject.SetActive(GameObject.Find("SpawnManager").GetComponent<SpawnManager>().gameOver);
    }
}
