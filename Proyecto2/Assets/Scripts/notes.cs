using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notes : MonoBehaviour
{


    public GameObject imagenDeNota; 

    private bool notaLeida = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nota") && !notaLeida)
        {
            Debug.Log("Entró en la zona de la nota.");
            imagenDeNota.SetActive(true); // Muestra la imagen de la nota
            notaLeida = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Nota"))
        {
            imagenDeNota.SetActive(false); // Oculta la imagen de la nota al alejarse
        }
    }


}
