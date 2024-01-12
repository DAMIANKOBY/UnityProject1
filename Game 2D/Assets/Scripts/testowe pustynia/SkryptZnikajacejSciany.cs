using UnityEngine;

public class SkryptZnikajacejSciany : MonoBehaviour
{
    public GameObject przejscie;
    public GameObject[] obiektyDoPokazania; // Tablica obiektów, które mają zniknąć

    void OnTriggerEnter2D(Collider2D collide) //other - gameObject
    {
        if (collide.gameObject.name == "Player") 
        {
            PokazObiekty();
            
        }
    }

    void PokazObiekty()
    {
        // Pokaż obiekty z tablicy, gdy gracz wejdzie w obszar
        foreach (GameObject obiekt in obiektyDoPokazania)
        {
            obiekt.SetActive(true);
        }
    }

    
}
