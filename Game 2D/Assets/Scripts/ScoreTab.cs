using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ScoreTab : MonoBehaviour
{
    public string sciezkaDoPliku = "Assets/Scenes/score.txt";
    public string MapName;
    public Text BestMapTimeView;

    public void ZnajdzNajwiekszyWynikDlaMapy()
    {
        if (File.Exists(sciezkaDoPliku))
        {
            string[] lines = File.ReadAllLines(sciezkaDoPliku);
            int bestTime = int.MaxValue;
            string bestTimeString = null;

            foreach (string line in lines)
            {
                if (line.Contains(MapName))
                {
                    // Podziel lini? na cz??ci po spacji
                    string[] parts = line.Split(' ');

                    // Sprawd?, czy jest co najmniej jedna cz??? po spacji
                    if (parts.Length > 1)
                    {
                        int t = TimeToSeconds(parts[5]);
                        if (t < bestTime)
                        {
                            bestTime = t;
                            bestTimeString = line;
                        }
                    }
                    else
                    {
                        Debug.LogError("Linia nie zawiera warto?ci po spacji.");
                    }
                }

            }
            BestMapTimeView.text = bestTimeString;
        }
        else
        {
            Debug.LogWarning("Plik nie istnieje: " + sciezkaDoPliku);
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
