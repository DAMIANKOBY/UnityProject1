using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    bool dirToRight = true;
    Rigidbody2D rgdBody;
    public float heroSpeed;
    public float jumpForce;
    private bool onTheGround;
    public Transform GroundTester;
    private float radius = 0.1f;
    public LayerMask layersToTest;
    public Transform startPoint;

    void Start()
    {
        anim = GetComponent<Animator>();
        rgdBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (horizontalMove < 0 && dirToRight)
        {
            Flip();
        }
        if (horizontalMove > 0 && !dirToRight)
        {
            Flip();
        }

        rgdBody.velocity = new Vector2(horizontalMove*heroSpeed, rgdBody.velocity.y);
        onTheGround = Physics2D.OverlapCircle(GroundTester.position, radius, layersToTest);

        if (Input.GetKeyDown(KeyCode.Space) && onTheGround)
        {
            rgdBody.AddForce(new Vector2(0f, jumpForce));
            anim.SetTrigger("Jump");
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            rgdBody.velocity = Vector2.zero;
            return;
        }

        if (rgdBody.velocity.y < -30)
            restartHero();

    }

    void Flip()
    {
        dirToRight = !dirToRight;
        Vector3 heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
    }

    public void restartHero() 
    {
        gameObject.transform.position = startPoint.position;
    }
}
