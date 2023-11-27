using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CounterControllerScore : MonoBehaviour
{
    int Score = 0;
    int MaxScore = 0;
    public Text counterScoreView;
    public GameObject player;
    int playerStartX;
    public Text gameOverScoreText;

    void Start()
    {
        ResetCounter();
        playerStartX = (int)player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Score = (int)player.transform.position.x - playerStartX;
        if (MaxScore < Score) MaxScore = Score;
        counterScoreView.text = "Score: " + MaxScore.ToString();
        gameOverScoreText.text = "Score: " + MaxScore.ToString();
    }

    

    public void ResetCounter()
    {
        MaxScore = 0;
        counterScoreView.text = "Score: " + MaxScore.ToString();
    }
}
