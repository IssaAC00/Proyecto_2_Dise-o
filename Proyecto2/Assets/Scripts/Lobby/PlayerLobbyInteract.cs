using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
  [SerializeField]
  private SceneInfo sceneInfo;

  [SerializeField]
  private Canvas LetterCanvas;

  [SerializeField]
  private AudioSource audioSource;

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
      if (collider.gameObject.name == "CartaObj")
      {
        if (sceneInfo.LobbyPuzzleCompleted)
        {
          Debug.Log("Puzzle de Lobby completado!");
        }
        else
        {
          audioSource.Play();
          sceneInfo.PlayerLobbyPos = transform.position;
          LetterCanvas.enabled = true;
        }
      }
    }
  }
}
