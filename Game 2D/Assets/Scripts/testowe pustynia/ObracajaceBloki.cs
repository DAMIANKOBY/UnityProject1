using UnityEngine;

public class ObracajaceBloki : MonoBehaviour
{
    public float predkoscObrotu = 100f; // Prędkość obrotu bloków
    public bool kierunekPrzeciwny = false; // True, jeśli bloki mają obracać się w przeciwnym kierunku

    void Update()
    {
        ObracajBloki();
    }

    void ObracajBloki()
    {
        // Określ kierunek obrotu
        int kierunek = kierunekPrzeciwny ? -1 : 1;

        // Obrót bieżącego obiektu (do którego jest przypisany ten skrypt) wokół osi Z z uwzględnieniem prędkości obrotu i kierunku
        transform.Rotate(Vector3.forward * kierunek * predkoscObrotu * Time.deltaTime);
    }
}
