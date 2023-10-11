using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStudioInteract : MonoBehaviour
{
  [SerializeField]
  private SceneInfo sceneInfo;

  [SerializeField]
  private Canvas LetterCanvas;

  [SerializeField]
  private AudioSource audioSource;

  private void Start()
  {
    //transform.position = sceneInfo.PlayerStudioPos;
    LetterCanvas.enabled = false;
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
        audioSource.Play();
        sceneInfo.PlayerStudioPos = transform.position;
        LetterCanvas.enabled = true;
      }
    }
  }
}
