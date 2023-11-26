using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{
    public GameObject finalScreen;
    // Start is called before the first frame update
    void Start()
    {
        finalScreen.SetActive(false);
}
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collide) //other - gameObject
    {
        if (collide.gameObject.name == "Player") 
        {
		Debug.LogError("The End");
		finalScreen.SetActive(true);
		Invoke("LoadNewLevel", 3f);
         }
	}

 void LoadNewLevel()
	{
	SceneManager.LoadScene("Simple Main Menu");
	} 
}