
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject HoleObject;
    public GameObject CropObject;
    public List<GameObject> players;
    private List<int> spotToOccupy  = Enumerable.Range(0, 100).ToList();
    private float HoleSpawnRate = 3.0f;
    private float CropSpawnRate = 2.0f;

    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("data manager: " + DataManager.Instance.selectedPlayer);
        int playerIndex = GetPrefabIndex(DataManager.Instance.selectedPlayer);
        Instantiate(players[playerIndex], new Vector3(Random.Range(0.2f, 9.8f), 0, Random.Range(0.2f, 9.8f)), players[0].transform.rotation);
        StartCoroutine(SpawnHole());
        StartCoroutine(SpawnCrop());
    }

    IEnumerator SpawnHole() {
        while (!gameOver) {
            yield return new WaitForSeconds(HoleSpawnRate);
            int spawnPosition = Random.Range(0, spotToOccupy.Count);
            // spawn hole in the position
            spotToOccupy.RemoveAt(spawnPosition);

            Instantiate(HoleObject, new Vector3(0.5f + GetPosX(spawnPosition), 0, 0.5f + GetPosY(spawnPosition)), HoleObject.transform.rotation);
        }
    }

    IEnumerator SpawnCrop() {
        while (!gameOver) {
            yield return new WaitForSeconds(CropSpawnRate);
            int spawnPosition = Random.Range(0, spotToOccupy.Count);
            Instantiate(CropObject, new Vector3(0.5f + GetPosX(spawnPosition), 0, 0.5f + GetPosY(spawnPosition)), HoleObject.transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private int GetPosX(int spawnPosition) {
        return (int)System.Math.Floor(System.Convert.ToDouble(spotToOccupy[spawnPosition] / 10));
    }

    private int GetPosY(int spawnPosition) {
        return spotToOccupy[spawnPosition] % 10;
    }

    private int GetPrefabIndex(string tag) {
        return tag switch
        {
            "Chicken" => 0,
            "Sheep" => 1,
            "Cow" => 2,
            _ => 0,
        };
    }
}
