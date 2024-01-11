using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ScoreTabAdventure : MonoBehaviour
{
    public string sciezkaDoPliku = "Assets/Scenes/score.txt";
    string MapName = "Infinity";
    public Text[] ScoresView = new Text[10];

    public void ZnajdzNajwiekszyWynikDlaMapy()
    {
        if (File.Exists(sciezkaDoPliku))
        {
            string[] lines = File.ReadAllLines(sciezkaDoPliku);

            // Lista przechowująca pary (linia tekstu, mapValue)
            List<(string, int)> scoresList = new List<(string, int)>();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (line.Contains(MapName))
                {
                    string[] parts = line.Split(' ');

                    if (parts.Length > 1)
                    {
                        if (int.TryParse(parts[3], out int mapValue))
                        {
                            scoresList.Add((line.Substring(8), mapValue));
                        }
                        else
                        {
                            Debug.LogError("Nie można przekształcić wartości na int.");
                        }
                    }
                    else
                    {
                        Debug.LogError("Linia nie zawiera wartości po spacji.");
                    }
                }
            }

            // Sortowanie listy po drugim elemencie (mapValue)
            scoresList.Sort((x, y) => y.Item2.CompareTo(x.Item2));

            // Wypisywanie posortowanych wyników do ScoresView
            for (int i = 0; i < Mathf.Min(scoresList.Count, ScoresView.Length); i++)
            {
                ScoresView[i].text = (i + 1) + ". Player: " + scoresList[i].Item1;
            }
        }
        else
        {
            Debug.LogWarning("Plik nie istnieje: " + sciezkaDoPliku);
        }
    }
}
