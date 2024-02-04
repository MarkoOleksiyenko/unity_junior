
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject HoleObject;
    public GameObject CropObject;
    private List<int> spotToOccupy  = Enumerable.Range(0, 100).ToList();
    private float HoleSpawnRate = 3.0f;
    private float CropSpawnRate = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHole());
        StartCoroutine(SpawnCrop());
    }

    IEnumerator SpawnHole() {
        while (true) {
            yield return new WaitForSeconds(HoleSpawnRate);
            int spawnPosition = Random.Range(0, spotToOccupy.Count);
            // spawn hole in the position
            spotToOccupy.RemoveAt(spawnPosition);

            Instantiate(HoleObject, new Vector3(0.5f + GetPosX(spawnPosition), 0, 0.5f + GetPosY(spawnPosition)), HoleObject.transform.rotation);
        }
    }

    IEnumerator SpawnCrop() {
        while (true) {
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
}
