using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LobbyButton : MonoBehaviour
{
  [SerializeField]
  private GameObject levelChanger;

  [SerializeField]
  private AudioSource audioSource;
  public void LoadPuzzle()
  {
    levelChanger.GetComponent<LevelChanger>().FadeToLevel();
    audioSource.Play();
    Invoke("LoadLevel", 1.1f);
  }

  private void LoadLevel()
  {
    SceneManager.LoadScene("LobbyPuzzle");
  }
}
