using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCollect : MonoBehaviour
{
    public AudioClip clip;
    private CounterController counterController;

    void Start()
    {
        counterController = GameObject.Find("Manager").GetComponent<CounterController>();
        if (counterController == null)
        {
            Debug.LogError("CounterController doesn't exist");
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            counterController.IncrementationCounter();
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }
}
