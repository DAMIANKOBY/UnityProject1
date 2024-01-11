using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreSave : MonoBehaviour
{
    public Text ScoreView;
    public Text PointsView;
    public Text TimeView;
    public string sciezkaDoPliku = "Assets/Scenes/score.txt";
    public string MapName;
    public Text Name;
    string n;

    public void ZapiszDoPliku()
    {
        string zawartosc;
        n = Name.text;
        if (n == "")
            n = "Unknown";
        if (ScoreView != null)
            zawartosc = MapName + " " + Name.text + " " + ScoreView.text;
        else
            zawartosc = MapName + " " + n + " " + PointsView.text + " " + TimeView.text;

        if (!File.Exists(sciezkaDoPliku))
        {
            File.WriteAllText(sciezkaDoPliku, zawartosc);
        }
        else
        {
            File.AppendAllText(sciezkaDoPliku, "\n" + zawartosc);
        }

        Debug.Log("Zapisano do pliku: " + sciezkaDoPliku);
    }
}
