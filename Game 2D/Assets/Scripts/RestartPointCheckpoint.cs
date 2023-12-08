//RestartPointCheckpoint

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPointCheckpoint : MonoBehaviour
{
    RestartPointManager restartPointManager;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        restartPointManager = GameObject.Find("Manager").GetComponent<RestartPointManager>();
        if (restartPointManager == null)
        {
            Debug.LogError("CounterController doesn't exist");
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            restartPointManager.UpdateStartPoint(this.gameObject.transform);

            if (spriteRenderer != null)
            {
                // Ustaw kolor na bia³y z przezroczystoœci¹ 50%
                spriteRenderer.color = new Color(0.1f, 0.4f, 0.7f);
            }
        }
    }
}
