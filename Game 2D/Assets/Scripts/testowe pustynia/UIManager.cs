using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text komunikatText;

    public static void WyswietlKomunikat(string komunikat)
    {
        // Pobierz referencję do UIManagera (może być tylko jeden w scenie)
        UIManager uiManager = FindObjectOfType<UIManager>();

        if (uiManager != null && uiManager.komunikatText != null)
        {
            uiManager.komunikatText.text = komunikat;
            uiManager.komunikatText.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Nie można znaleźć UIManagera lub komunikatText nie jest ustawiony.");
        }
    }
}
