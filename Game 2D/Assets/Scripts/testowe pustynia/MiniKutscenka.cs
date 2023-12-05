using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class MiniKutscenka : MonoBehaviour
{
    public Text napisPrzejscia;
    public float czasWyswietlania = 3f;

    private void Start()
    {
        // Ukryj napis na początku
        if (napisPrzejscia != null)
        {
            napisPrzejscia.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Uruchom mini katscenkę, gdy gracz wejdzie w obszar
            StartCoroutine(RozpocznijMiniKutscenke());
        }
    }

    private IEnumerator RozpocznijMiniKutscenke()
    {
        // Wyświetl napis
        if (napisPrzejscia != null)
        {
            napisPrzejscia.gameObject.SetActive(true);
        }

        // Zastosuj efekt przejścia (tu można dodać efekty dźwiękowe, animacje, itp.)

        // Poczekaj przez zadaną liczbę sekund
        yield return new WaitForSeconds(czasWyswietlania);

        // Ukryj napis po zakończeniu mini-kutscenki
        if (napisPrzejscia != null)
        {
            napisPrzejscia.gameObject.SetActive(false);
        }

        // Załaduj nowy poziom (lub inny docelowy obiekt, np. na mapie)
        // Tutaj możesz dostosować, co ma się dziać po zakończeniu mini-kutscenki
        Debug.Log("Przejście do nowego poziomu lub innej akcji po zakończeniu mini-kutscenki.");
        // Na przykład, załaduj nowy poziom:
        // SceneManager.LoadScene("NazwaDocelowegoPoziomu");
    }
}