using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
  [SerializeField]
  private SceneInfo sceneInfo;

  [SerializeField]
  private GameObject levelChanger;

  private void Start()
  {
    transform.position = sceneInfo.PlayerLobbyPos;
  }
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.E))
    {
      InteractAction();
    }
  }

  private void InteractAction()
  {
    Collider2D[] nearColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
    foreach (Collider2D collider in nearColliders)
    {
      if (collider.CompareTag("Interact"))
      {
        if (sceneInfo.LobbyPuzzleCompleted)
        {
          Debug.Log("Puzzle de Lobby completado!");
        }
        else
        {
          sceneInfo.PlayerLobbyPos = transform.position;
          levelChanger.GetComponent<LevelChanger>().FadeToLevel();
          Invoke("ChangeScene", 1.1f);
        }
      }
    }
  }
  
  private void ChangeScene()
  {
    SceneManager.LoadScene("LobbyPuzzle");
  }
}
