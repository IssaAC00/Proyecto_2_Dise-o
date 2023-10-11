using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonKids : MonoBehaviour
{
    [SerializeField]
    private GameObject levelChanger;

   
    public void LoadPuzzle()
    {
        levelChanger.GetComponent<LevelChanger>().FadeToLevel();
 
        Invoke("LoadLevel", 1.1f);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene("SlidingKidsRoom");
    }
}
