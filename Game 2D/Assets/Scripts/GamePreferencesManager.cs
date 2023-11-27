//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class GamePreferencesManager : MonoBehaviour
//{
//    const string ScoreKey = "Srore";
//    void Start()
//    {
//        LoadPrefs();
//    }
//
//    
//    void Update()
//    {
//        SavePrefs();
//    }
//
//    public void SavePrefs()
//    {
//        PlayerPrefs.SetInt(ScoreKey, GameViewController.Instance.CurrentScore);
//        PlayerPrefs.Save();
//    }
//
//    public void LoadPrefs()
//    {
//        var score = PlayerPrefs.GetInt(ScoreKey, 0);
//        GameViewController.Instance.CurrentScore = score;
//    }
//}
