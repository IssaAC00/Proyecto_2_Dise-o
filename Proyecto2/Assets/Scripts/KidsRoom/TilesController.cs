using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesController : MonoBehaviour
{

    public Vector3 TragetPosition;
    private Vector3 correctPosition;
    private SpriteRenderer spriteRenderer;
    public int number;
    public bool inRightPlace;
    // Start is called before the first frame update
    void Awake()
    {
        TragetPosition = transform.position;
        correctPosition = TragetPosition;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(a: transform.position, b: TragetPosition, t: 0.05f);
        if (correctPosition == TragetPosition)
        {
            spriteRenderer.color = Color.green;
            inRightPlace = true;
        }
        else { 
            spriteRenderer.color= Color.white;
            inRightPlace = false;
        }
    }
}
