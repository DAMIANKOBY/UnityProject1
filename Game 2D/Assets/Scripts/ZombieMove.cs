using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    public float speed;
    public Vector2 startPoint;
    public Vector2 endPoint;
    private Vector3 currentPlatformPosition;
    public Transform NavStartPoint;
    public Transform NavEndPoint;
    bool dirToRight = true;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        startPoint = NavStartPoint.position;
        endPoint = NavEndPoint.position;
        Destroy(NavStartPoint.gameObject);
        Destroy(NavEndPoint.gameObject);
    }
    
    void Update()
    {
        currentPlatformPosition = Vector2.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
        transform.position = new Vector3(currentPlatformPosition.x, transform.position.y, transform.position.z);

        float horizontalMove = Mathf.Abs(Mathf.Sin(Time.time * speed));
        anim.SetFloat("speed", horizontalMove);
        if (currentPlatformPosition.x <= startPoint.x + 0.05 && !dirToRight)
        {
            Flip();
        }
        else if (currentPlatformPosition.x >= endPoint.x-0.05 && dirToRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        dirToRight = !dirToRight;
        Vector3 zombieScale = gameObject.transform.localScale;
        zombieScale.x *= -1;
        gameObject.transform.localScale = zombieScale;
    }
}
