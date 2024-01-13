using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetLevel : MonoBehaviour
{
    public string scene;
    public PlayerController playerController;
    Transform spawn;
    public Text timerText;
    string Timer;
    int seconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            spawn = playerController.GetSpawn();
            PlayerPrefs.SetString("SpawnName", spawn.name);
            Timer = timerText.text;
            seconds = TimeToSeconds(Timer.Substring(6));
            PlayerPrefs.SetInt("Timer", seconds);
            SceneManager.LoadScene(scene);
        }
    }

    int TimeToSeconds(string czas)
    {
        string[] czesciCzasu = czas.Split(':');
        int minuty = System.Int32.Parse(czesciCzasu[0]);
        int sekundy = System.Int32.Parse(czesciCzasu[1]);
        return minuty * 60 + sekundy;
    }
}
