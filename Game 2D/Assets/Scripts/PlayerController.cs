using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool restarted = true;

    public AudioClip DeadSound;
    public AudioClip JumpStartSound;
    public AudioClip JumpEndSound;
    AudioSource audioSrc;

    public bool useLives;
    public int amountOfLives = 1;
    public GameObject gameOverScreen;
    public Text livesText;

    bool isFalling = false;

    GameObject Manager;

    void Start()
    {
        anim = GetComponent<Animator>();
        rgdBody = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (useLives == true)
            livesText.text = "Lives: " + amountOfLives.ToString();

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

        rgdBody.velocity = new Vector2(horizontalMove * heroSpeed, rgdBody.velocity.y);
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


        if (gameObject.transform.position.y < -30 && !isFalling)
        {
            isFalling = true;
            Dead();
            AudioSource.PlayClipAtPoint(DeadSound, transform.position);
        }

        if (anim.GetBool("Fail") == true) Dead();

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            rgdBody.velocity = Vector2.zero;
        }
    }

    void Flip()
    {
        dirToRight = !dirToRight;
        Vector3 heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
    }

    public IEnumerator restartHero()
    {
        yield return new WaitForSeconds(1f);
        Quaternion rotate = new Quaternion(0, 0, 0, 0);
        gameObject.transform.rotation = rotate;
        if (!restarted ) {
            gameObject.transform.position = startPoint.position;
        }
        restarted = true;
        isFalling = false;
    }

    public void Dead()
    {
        restarted = false;
        if (useLives == true)
        {
            amountOfLives -= 1;
            if (amountOfLives > 0)
                StartCoroutine(restartHero());
            else
            {
                Debug.LogError("Game Over");
                gameOverScreen.SetActive(true);
            }
        }
        else
            StartCoroutine(restartHero());
    }
}
