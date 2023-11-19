using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KulaTriger : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public GameObject hero;
	public GameObject triger;
    // Start is called before the first frame update
    void Start()
    {

	rb2d = GetComponent<Rigidbody2D>();

        rb2d.isKinematic = true;
        
    }

    // Update is called once per frame
    void Update()
    {
	float wspolrzednaXGracza = hero.transform.position.x;
        if( wspolrzednaXGracza > triger.transform.position.x){
		
		rb2d.isKinematic = false;
		Debug.Log("Współrzędna X gracza: " + wspolrzednaXGracza);
	}
    }
}