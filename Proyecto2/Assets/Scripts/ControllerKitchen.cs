using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private SceneInfo sceneInfo;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GameObject levelChanger;


    private void Start()
    {
        transform.position = sceneInfo.PlayerKitchenPos;
        canvas.enabled = false;
    }

    private void Interaction()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,1f);
        foreach (Collider2D collider in colliders)
        {
            if(collider.gameObject.name == "CartaObj")
            {
                if(sceneInfo.KitchenPuzzleCompleted == false)
                {
                    SceneManager.LoadScene("Memory Game");

                }
            }else if (collider.gameObject.name == "PuertaCuarto")
            {
                sceneInfo.PlayerKitchenPos = transform.position;
                collider.gameObject.GetComponent<AudioSource>().Play();
                levelChanger.GetComponent<LevelChanger>().FadeToLevel();
                Invoke("LoadRoom", 1.1f);
            }
            else if (collider.gameObject.name == "PuertaLobby")
            {
                sceneInfo.PlayerKitchenPos = transform.position;
                collider.gameObject.GetComponent<AudioSource>().Play();
                levelChanger.GetComponent<LevelChanger>().FadeToLevel();
                Invoke("LoadLobby", 1.1f);
            }
        }
    }

    private void LoadRoom()
    {
        SceneManager.LoadScene("KidsRoom");
    }

    private void LoadLobby()
    {
        SceneManager.LoadScene("Lobby");
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interaction();
        }
    }
}
