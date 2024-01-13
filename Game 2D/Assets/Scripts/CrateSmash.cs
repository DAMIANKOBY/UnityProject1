using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSmash : MonoBehaviour
{
    Vector3 nowaSkala;
    bool IsSmash = false;
    // Start is called before the first frame update
    void Start()
    {
         nowaSkala = new Vector3(2f, 0.1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && IsSmash == false)
        {
            IsSmash = true; 
            gameObject.transform.localScale = nowaSkala;
        }
    }
}
