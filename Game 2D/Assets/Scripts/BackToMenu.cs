using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToMenu : MonoBehaviour
{
    void Start()
    {
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Simple Main Menu");
    }
}
