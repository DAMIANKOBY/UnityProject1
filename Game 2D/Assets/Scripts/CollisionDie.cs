using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDie : MonoBehaviour
{
    public AudioClip DeadSound;
    bool isColliding = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !isColliding)
        {
            isColliding = true;
            collision.gameObject.GetComponent<Animator>().SetTrigger("Fail");
            AudioSource.PlayClipAtPoint(DeadSound, transform.position);

            StartCoroutine(ResetCollisionFlag());
        }
    }

    IEnumerator ResetCollisionFlag()
    {
        // Wait for a short duration before resetting the flag
        yield return new WaitForSeconds(2f); // Adjust the duration as needed

        isColliding = false;
    }
}
