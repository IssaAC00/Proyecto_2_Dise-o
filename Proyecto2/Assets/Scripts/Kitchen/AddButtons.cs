using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    private Transform puzzleField;
    [SerializeField]
    private GameObject button;

    private void Awake()
    {
        for (int i = 0; i < 18; i++) 
        { 
            GameObject _button = Instantiate(button);
            _button.name = "" + i;
            _button.transform.SetParent(puzzleField, false);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
