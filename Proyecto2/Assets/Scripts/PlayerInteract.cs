using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
  [SerializeField]
  private SceneInfo sceneInfo;
  // Update is called once per frame
  void Update()
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
        Debug.Log("Desplegando Puzzle");
      }
    }
  }
}
