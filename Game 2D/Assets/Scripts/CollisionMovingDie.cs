using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMovingDie : MonoBehaviour
{

    public AudioClip DeadSound;
    bool isColliding = false; 
    public float speed;
    public Vector2 startPoint;
    public Vector2 endPoint;
    private Vector2 currentPlatformPosition;
    public Transform NavStartPoint;
    public Transform NavEndPoint;

    void Start()
    {
        startPoint = NavStartPoint.position;
        endPoint = NavEndPoint.position;
        Destroy(NavStartPoint.gameObject);
        Destroy(NavEndPoint.gameObject);
    }

    void Update()
    {
        currentPlatformPosition = Vector2.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
        transform.position = currentPlatformPosition;
    }

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
        yield return new WaitForSeconds(1f); // Adjust the duration as needed

        isColliding = false;
    }
}
