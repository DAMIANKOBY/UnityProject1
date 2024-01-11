using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ScoreRead : MonoBehaviour
{
    public string sciezkaDoPliku = "Assets/Scenes/score.txt";
    public string MapName;
    public Text BestScoreText;

    public void ZnajdzNajwiekszyWynikDlaMapy()
    {
        if (File.Exists(sciezkaDoPliku))
        {
            string[] lines = File.ReadAllLines(sciezkaDoPliku);
            int maxScore = 0;

            foreach (string line in lines)
            {
                if (line.Contains(MapName))
                {
                    // Podziel lini? na cz??ci po spacji
                    string[] parts = line.Split(' ');

                    // Sprawd?, czy jest co najmniej jedna cz??? po spacji
                    if (parts.Length > 1)
                    {
                        // Próbuj przekszta?ci? drug? cz??? na int
                        if (int.TryParse(parts[3], out int mapValue))
                        {
                            // Zapisz mapValue jako int
                            Debug.Log("Warto?? mapy: " + mapValue);
                            if (maxScore < mapValue)
                                maxScore = mapValue;
                        }
                        else
                        {
                            Debug.LogError("Nie mo?na przekszta?ci? warto?ci na int.");
                        }
                    }
                    else
                    {
                        Debug.LogError("Linia nie zawiera warto?ci po spacji.");
                    }
                }

            }
            BestScoreText.text = "Best Score: " + maxScore.ToString();
        }
        else
        {
            Debug.LogWarning("Plik nie istnieje: " + sciezkaDoPliku);
        }
    }
}
