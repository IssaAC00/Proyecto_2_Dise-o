using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKitchenInteract : MonoBehaviour
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
            //InteractAction();
        }
    }

    private void InteractAction()
    {
        Collider2D[] nearColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (Collider2D collider in nearColliders)
        {
            // Check Letter
            if (collider.gameObject.name == "Carta")
            {
                if (sceneInfo.KitchenPuzzleCompleted == false)
                {
                    collider.gameObject.GetComponent<AudioSource>().Play();
                    sceneInfo.PlayerKitchenPos = transform.position;
                    LetterCanvas.enabled = true;
                }
            }
            // Check Room Door
            else if (collider.gameObject.name == "PuertaCuarto")
            {
                collider.gameObject.GetComponent<AudioSource>().Play();
                sceneInfo.PlayerLobbyPos = transform.position;
                levelChanger.GetComponent<LevelChanger>().FadeToLevel();
                Invoke("LoadKidsRoom", 1.1f);
            }
            // Check Loby Door

            else if (collider.gameObject.name == "PuertaLoby")
            {
                
            }
        }
    }

    private void LoadLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    private void LoadKidsRoom()
    {
        SceneManager.LoadScene("KidsRoom");
    }

    // Update is called once per frame

}
