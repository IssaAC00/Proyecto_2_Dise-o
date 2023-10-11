using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudioPuzzleController : MonoBehaviour
{
    [SerializeField] private PinController[] pins;
    [SerializeField] private int[] correctGearTypes;
    private bool[] correctPins;

    // Start is called before the first frame update
    void Start()
    {
        correctPins = new bool[pins.Length];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            if(pins[i].gear != null && pins[i].gear.GetGearType() == correctGearTypes[i])
                correctPins[i] = true;
            else
                correctPins[i] = false;
        }
        CheckCompleted();
    }

    private void CheckCompleted()
    {
        foreach (bool state in correctPins)
        {
            if(state == false)
                return;
        }
        //All pins are correct
        Debug.Log("Todos los pines estan correctos.");
    }
}
