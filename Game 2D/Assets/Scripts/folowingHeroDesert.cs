using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folowingHeroDesert : MonoBehaviour
{
    public GameObject hero;
    public float smoothTime;
    private Vector3 currentVel;

    void Start()
    {
        
    }


    void Update()
    {
        Vector3 newCameraPosition = new Vector3(hero.transform.position.x, hero.transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, newCameraPosition, ref currentVel, smoothTime);
    }
}
