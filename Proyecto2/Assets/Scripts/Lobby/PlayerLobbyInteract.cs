using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
  [SerializeField]
  private SceneInfo sceneInfo;

  [SerializeField]
  private Canvas LetterCanvas;

  [SerializeField]
  private GameObject levelChanger;

  private void Start()
  {
    transform.position = sceneInfo.PlayerLobbyPos;
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
      // Check Letter
      if (collider.gameObject.name == "CartaObj")
      {
        if (sceneInfo.LobbyPuzzleCompleted == false)
        {
          collider.gameObject.GetComponent<AudioSource>().Play();
          sceneInfo.PlayerLobbyPos = transform.position;
          LetterCanvas.enabled = true;
        }
      }
      // Check Kitchen Door
      else if (collider.gameObject.name == "PuertaCocina")
      {
        collider.gameObject.GetComponent<AudioSource>().Play();
        sceneInfo.PlayerLobbyPos = transform.position;
        levelChanger.GetComponent<LevelChanger>().FadeToLevel();
        Invoke("LoadCocina", 1.1f);
      }
      // Check Studio Door

      else if (collider.gameObject.name == "PuertaEstudio")
      {
        AudioSource[] audios = collider.gameObject.GetComponents<AudioSource>();
        if(sceneInfo.LobbyPuzzleCompleted && sceneInfo.KitchenPuzzleCompleted && sceneInfo.KidsRoomPuzzleCompleted)
        {
          audios[0].Play();
          sceneInfo.PlayerLobbyPos = transform.position;
          levelChanger.GetComponent<LevelChanger>().FadeToLevel();
          Invoke("LoadStudio", 1.1f);
        }
        else
        {
          audios[1].Play();
        }
        
      }

      // Check House Main Door
      else if (collider.gameObject.name == "PuertaCasa")
      {
        collider.gameObject.GetComponent<AudioSource>().Play();
      }

    }
  }

  private void LoadCocina()
  {
    SceneManager.LoadScene("Kitchen");
  }

  private void LoadStudio()
  {
    SceneManager.LoadScene("Studio");
  }
}
