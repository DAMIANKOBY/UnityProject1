using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
            other.attachedRigidbody.Sleep();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
