using UnityEngine;

public class Ladder_wiszenie : MonoBehaviour
{
    public float climbingSpeed = 5f;
    public float jumpForce = 10f;

    private bool isClimbing = false;
    private Rigidbody2D playerRigidbody;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isClimbing = true;
            playerRigidbody = other.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                playerRigidbody.gravityScale = 0f;  // Wyłącz grawitację, aby gracz nie opadał z drabiny
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isClimbing = false;
            if (playerRigidbody != null)
            {
                playerRigidbody.gravityScale = 1f;  // Włącz z powrotem grawitację
            }
        }
    }

    void Update()
    {
        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical");
            ClimbLadder(verticalInput);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }

    void ClimbLadder(float verticalInput)
    {
        // Ruch w pionie
        Vector2 newPosition = playerRigidbody.position + new Vector2(0f, verticalInput * climbingSpeed * Time.deltaTime);
        playerRigidbody.MovePosition(newPosition);

        // Ruch w poziomie
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0f)
        {
            Vector2 horizontalMovement = new Vector2(horizontalInput * climbingSpeed * Time.deltaTime, 0f);
            playerRigidbody.MovePosition(playerRigidbody.position + horizontalMovement);
        }
    }

    void Jump()
    {
        // Skok
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
    }
}
