using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenButton : MonoBehaviour
{
    [SerializeField] private LevelChanger levelChanger;
    [SerializeField] private AudioSource audioSource;

    public void LoadPuzzle()
    {
        // Usamos levelChanger directamente en lugar de GetComponent
        levelChanger.FadeToLevel();

        // Reproducimos el sonido si el audioSource está configurado
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Usamos una corrutina para cargar la escena después de un retraso
        StartCoroutine(LoadLevelAfterDelay(1.1f));
    }

    private IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Memory Game");
    }
}