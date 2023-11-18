using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CounterController : MonoBehaviour
{
    int NumberOfPoints;
    public Text counterView;
    // Start is called before the first frame update
    void Start()
    {
        ResetCounter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementationCounter()
    {
        NumberOfPoints++;
        counterView.text = "Points: " + NumberOfPoints.ToString();
    }

    public void ResetCounter()
    {
        NumberOfPoints = 0;
        counterView.text = "Points: " + NumberOfPoints.ToString();
    }
}
