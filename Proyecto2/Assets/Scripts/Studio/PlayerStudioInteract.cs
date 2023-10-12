using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStudioInteract : MonoBehaviour
{
  [SerializeField] private SceneInfo sceneInfo;

  [SerializeField] private Canvas LetterCanvas;
  [SerializeField] private GameObject levelChanger;

  [SerializeField] private AudioSource audioSource;

  private void Start()
  {
    transform.position = sceneInfo.PlayerStudioPos;
    LetterCanvas.enabled = false;
  }
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.E) && !LetterCanvas.enabled)
    {
      InteractAction();
    }
  }

  private void InteractAction()
  {
    Collider2D[] nearColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
    foreach (Collider2D collider in nearColliders)
    {
      if (collider.gameObject.name == "Letter")
      {
        audioSource.Play();
        sceneInfo.PlayerStudioPos = transform.position;
        LetterCanvas.enabled = true;
      }
      else if (collider.gameObject.name == "Door")
      {
        collider.gameObject.GetComponent<AudioSource>().Play();
        sceneInfo.PlayerStudioPos = transform.position;
        levelChanger.GetComponent<LevelChanger>().FadeToLevel();
        Invoke("LoadLobby", 1.1f);
      }
    }
  }

  private void LoadLobby()
  {
    SceneManager.LoadScene("Lobby");
  }
}
