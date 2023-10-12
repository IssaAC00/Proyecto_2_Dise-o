using UnityEngine;
using UnityEngine.SceneManagement;

public class StudioPuzzleController : MonoBehaviour
{
    [Header("Scene Control")]
    [SerializeField] private LevelChanger levelChanger;

    [Header("Puzzle Settings")]
    [SerializeField] private PinController[] pinList;
    [SerializeField] private int[] pinSolutions;
    [SerializeField] private bool[] pinRotations;
    private bool correctChain;

    [Header("Gear Animations")]
    [SerializeField] private Animator endGear;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        correctChain = true;
        //Check every pin
        for (int i = 0; i < pinList.Length; i++)
        {
            GearController connectedGear = pinList[i].gear;
            if (connectedGear != null && connectedGear.GetGearType() == pinSolutions[i])
            {
                if (correctChain)
                {
                    connectedGear.Animation_SetConnect(true);
                    connectedGear.Animation_SetRotation(pinRotations[i]);
                }
                else
                    connectedGear.Animation_SetConnect(false);
            }
            else
            {
                correctChain = false;
            }
        }
        if (correctChain)
        {
            endGear.SetBool("IsConnected", true);
            PuzzleCompleted();
        }

    }

    private void PuzzleCompleted()
    {
        Invoke("ActivateFade", 4.0f);
        Invoke("LoadEndScene", 5.0f);
    }

    private void ActivateFade()
    {
        levelChanger.FadeToLevel();
    }

    private void LoadEndScene()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
