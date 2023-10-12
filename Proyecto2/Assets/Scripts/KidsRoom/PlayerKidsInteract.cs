using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KidsRoomInteract : MonoBehaviour
{
    [SerializeField]
    private SceneInfo sceneInfo;

    [SerializeField]
    private Canvas LetterCanvas;

    [SerializeField]
    private GameObject levelChanger;

    private void Start()
    {
        transform.position = sceneInfo.PlayeKidsRoomPos;
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
            if (collider.gameObject.tag == "Carta")
            {
                if (sceneInfo.KidsRoomPuzzleCompleted == false)
                {
                   
                   
                    sceneInfo.PlayeKidsRoomPos = transform.position;
                    LetterCanvas.enabled = true;
                }
                else
                {
                    Debug.Log("Puzzle de Room completado!");
                }
               
            }
            if (collider.gameObject.tag == "Puerta")
            {
                Invoke("LoadCocina", 1.1f);
            }
        }
    }

    private void LoadCocina()
    {
        SceneManager.LoadScene("Kitchen");
    }


}
