using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenButtons : MonoBehaviour
{
  [SerializeField]
  private GameObject levelChanger;

  [SerializeField]
  private AudioSource audioSource;

  public void MenuButton()
  {
    audioSource.Play();
    levelChanger.GetComponent<LevelChanger>().FadeToLevel();
    Invoke("LoadMain", 1.1f);
  }

  public void QuitButton()
  {
    audioSource.Play();
    levelChanger.GetComponent<LevelChanger>().FadeToLevel();
    Invoke("ExitGame", 1.1f);
  }

  private void ExitGame()
  {
    Application.Quit();
  }

  private void LoadMain()
  {
    SceneManager.LoadScene("StartGame");
  }
}
