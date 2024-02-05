using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    private float lowX = 0.2f;
    private float highX = 9.8f;
    private float lowZ = 0.2f;
    private float highZ = 9.8f;
    private float speed = 5.0f;
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 newPosition = gameObject.transform.position + new Vector3(horizontal * Time.deltaTime * speed, 0, vertical * Time.deltaTime * speed);
        MovementBoundaries(newPosition);
    }

    private void MovementBoundaries(Vector3 newPosition)
    {
        if (!(newPosition.x < lowX || newPosition.x > highX || newPosition.z < lowZ || newPosition.z > highZ) && !GameObject.Find("SpawnManager").GetComponent<SpawnManager>().gameOver)
        {
            gameObject.transform.position = newPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dirt"))
        {
            GameObject.Find("SpawnManager").GetComponent<SpawnManager>().gameOver = true;
        }
        else if (other.CompareTag("Corn"))
        {
            Destroy(other.gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().score += 5;
        }
    }
}
