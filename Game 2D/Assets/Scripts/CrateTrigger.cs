using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CrateTrigger : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.isKinematic = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -30)
        {
            Destroy(this.gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            rb2d.isKinematic = false;
        }
    }
}
