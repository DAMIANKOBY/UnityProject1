using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CollisionDie : MonoBehaviour
{
    public AudioClip DeadSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Fail");
            AudioSource.PlayClipAtPoint(DeadSound, transform.position);
        }
    }

    void Start()
    {
        
    }

 
    void Update()
    {

    }
}
