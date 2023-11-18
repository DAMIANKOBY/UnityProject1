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
    private bool isMoving = false;
    private bool inAir = false;

    public AudioClip DeadSound;
    public AudioClip JumpStartSound;
    public AudioClip JumpEndSound;
    AudioSource audioSrc;

    void Start()
    {
        anim = GetComponent<Animator>();
        rgdBody = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
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

        if (rgdBody.velocity.x != 0)
            isMoving = true;
        else
            isMoving = false;

        if (isMoving && onTheGround)
        {
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        }
        else
            audioSrc.Stop();

        rgdBody.velocity = new Vector2(horizontalMove*heroSpeed, rgdBody.velocity.y);
        onTheGround = Physics2D.OverlapCircle(GroundTester.position, radius, layersToTest);

        if (Input.GetKeyDown(KeyCode.Space) && onTheGround)
        {
            rgdBody.AddForce(new Vector2(0f, jumpForce));
            anim.SetTrigger("Jump");
            AudioSource.PlayClipAtPoint(JumpStartSound, transform.position);
        }

        if (inAir && onTheGround)
            AudioSource.PlayClipAtPoint(JumpEndSound, transform.position);

        if (onTheGround)
            inAir = false;
        else
            inAir = true;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            rgdBody.velocity = Vector2.zero;
            return;
        }

        if (rgdBody.velocity.y < -30)
        {
            AudioSource.PlayClipAtPoint(DeadSound, transform.position);
            restartHero();
        }
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
