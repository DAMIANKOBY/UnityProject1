using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KulaTriger : MonoBehaviour
{
	public Rigidbody2D rb2d;
	public BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {

	rb2d = GetComponent<Rigidbody2D>();

        rb2d.isKinematic = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void triger()
    {
        
            rb2d.isKinematic = false;
        
    }

}
