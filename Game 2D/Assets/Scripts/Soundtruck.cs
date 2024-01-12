using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtruck : MonoBehaviour
{
    public AudioClip Audio;
    AudioSource AS;
    
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (AS.isPlaying == false)
        {
            AS.clip = Audio;
            AS.Play();
        }
    }
}
