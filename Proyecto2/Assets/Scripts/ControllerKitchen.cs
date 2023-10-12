using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private SceneInfo sceneInfo;
    [SerializeField]
    private Canvas canvas;


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
            if(collider.gameObject.name == "Carta")
            {
                if(sceneInfo.KitchenPuzzleCompleted == false)
                {
                    sceneInfo.PlayerKitchenPos = transform.position;
                    canvas.enabled = true;

                }
            }
        }
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interaction();
        }
    }
}
