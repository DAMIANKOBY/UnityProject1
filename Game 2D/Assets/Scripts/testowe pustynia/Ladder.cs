using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbingSpeed = 5f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float verticalInput = Input.GetAxis("Vertical");

            if (verticalInput > 0f)
            {
                ClimbLadder(other.gameObject, verticalInput);
            }
            else if (verticalInput < 0f)
            {
                DescendLadder(other.gameObject, verticalInput);
            }
            else
            {
                StopClimbing(other.gameObject);
            }
        }
    }

    void ClimbLadder(GameObject player, float verticalInput)
    {
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, verticalInput * climbingSpeed);
    }

    void DescendLadder(GameObject player, float verticalInput)
    {
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, verticalInput * climbingSpeed);
    }

    void StopClimbing(GameObject player)
    {
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerRigidbody.velocity = Vector2.zero;
    }
}
