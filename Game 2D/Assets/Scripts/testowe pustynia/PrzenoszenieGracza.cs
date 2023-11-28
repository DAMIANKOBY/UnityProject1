using UnityEngine;

public class PrzenoszenieGracza : MonoBehaviour
{
    public GameObject tabliczkaDocelowa;
    public string komunikatWejścia;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Gracz wszedł w obszar tabliczki");

            // Sprawdź, czy podano obiekt tabliczki docelowej
            if (tabliczkaDocelowa != null)
            {
                // Deaktywuj obiekt gracza na tabliczce źródłowej
                collision.gameObject.SetActive(false);

                // Przenieś gracza do tabliczki docelowej
                collision.transform.position = tabliczkaDocelowa.transform.position;
                Debug.Log($"Przeniesienie gracza do tabliczki docelowej");

                // Aktywuj obiekt gracza na tabliczce docelowej
                collision.gameObject.SetActive(true);

                // Wyświetl komunikat na konsoli
                if (!string.IsNullOrEmpty(komunikatWejścia))
                {
                    Debug.Log(komunikatWejścia);
                }
            }
            else
            {
                Debug.LogError("Nie podano obiektu tabliczki docelowej. Sprawdź skrypt.");
            }
        }
    }
}
