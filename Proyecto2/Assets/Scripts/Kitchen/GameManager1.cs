using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GameManager1 : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;
    [SerializeField]
    private SceneInfo sceneInfo;
    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<Button> btns = new List<Button>();
    private bool firstGuess, secondGuess;
    private int countGuess;
    private int countCorrectGuesses;
    private int gameGuesses;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessesPuzzle, secondGuessesPuzzle;
    public GameObject GameWinPopUp;
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
        gameGuesses = gamePuzzles.Count / 2;
        Shuffle(gamePuzzles);
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
        for(int i = 0; i < looper; i++)
        {
            if(index == looper / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
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
        //string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessesPuzzle = gamePuzzles[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessesPuzzle = gamePuzzles[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            if(firstGuessesPuzzle == secondGuessesPuzzle)
            {
                print("Puzzle Match");
            }
            else
            {
                print("Puzzle don't Match");
            }
            StartCoroutine(checkThePuzzleMatch());
        }
    }
    IEnumerator checkThePuzzleMatch()
    {
        yield return new WaitForSeconds(0.5f);
        if (firstGuessesPuzzle == secondGuessesPuzzle)
        {
            yield return new WaitForSeconds(0.5f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;
            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            CheckTheGameFinished();

        }
        else
        {
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }
        yield return new WaitForSeconds(0.5f);
        firstGuess = secondGuess = false;
    }
    void CheckTheGameFinished()
    {
        countCorrectGuesses++;
        if(countCorrectGuesses == gameGuesses)
        {
            print("Game Finish");
            GameWinPopUp.SetActive(true);
            sceneInfo.KitchenPuzzleCompleted = true;
        }
    }
    public void GotoBtnClick()
    {
        SceneManager.LoadScene("Kitchen");
        print("next click");
    }

    public void RetryBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        print("retry click");
    }

    void Shuffle(List<Sprite> list)
    {
        for(int i = 0; i<list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
