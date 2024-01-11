using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float seconds = 0f;
    private bool isTimerRunning = true;
    public GameObject LevelComplete;
    public Text EndTime;

    void Update()
    {
        if (isTimerRunning)
        {
            seconds += Time.deltaTime;

            string minutes = Mathf.Floor(seconds / 60).ToString("00");
            string secs = (seconds % 60).ToString("00");

            timerText.text = "Time: " + minutes + ":" + secs;
            EndTime.text = "Time: " + minutes + ":" + secs;
        }
        if (LevelComplete.activeSelf)
            StopTimer();
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }
}
