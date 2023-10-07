using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager1 : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;
    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    private void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("PuzzleImagenes/animals-6392140_1280");
    }
    // Start is called before the first frame update
    void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
    }

   void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("puzzleBtn");
        for(int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }


    }

    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;
        for(int i =0; i < looper; i++)
        {
            if(index == looper / 2)
            {
                index = 0;
                gamePuzzles.Add(puzzles[index]);
                index++;
            }
        }
            
     }

    void AddListeners()
    {
        foreach(Button btn in btns) 
        {
            btn.onClick.AddListener(() => PickPuzzle());
        }
    }

    public void PickPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        print("Hey" + name);
    }
}
