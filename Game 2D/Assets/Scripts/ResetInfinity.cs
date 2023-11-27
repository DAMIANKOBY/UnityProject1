using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetInfinity : MonoBehaviour
{
    public void Start()
    {
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Infinity");
    }
}
