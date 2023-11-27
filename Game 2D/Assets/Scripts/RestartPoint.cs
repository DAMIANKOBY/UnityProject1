using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPoint : MonoBehaviour
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
            if (spriteRenderer != null) spriteRenderer.color = new Color(0.3f, 0.7f, 0.2f);
        }
    }

}
