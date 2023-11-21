using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFloorGen : MonoBehaviour
{
    [SerializeField] GameObject[] floorPrefab;
    public float xPos;
    public float yPos;
    Vector3 position;
    GameObject[] gameObjects = new GameObject[5];
    public Transform parent;
    Transform parentObject; 

    void Start()
    {
        position = new Vector3(xPos, yPos);
        parentObject = parent.transform; 

        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i] = Instantiate(floorPrefab[Random.Range(0, floorPrefab.Length)], position, Quaternion.identity, parentObject);
            position.x += 20;
        }
    }

    void Update()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null && gameObjects[i].transform.position.x + 60 < gameObject.transform.position.x)
            {
                Destroy(gameObjects[i]);
                gameObjects[i] = Instantiate(floorPrefab[Random.Range(0, floorPrefab.Length)], position, Quaternion.identity, parentObject);
                position.x += 20;
            }
        }
    }
}
