using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform emptySpace = null;
    private Camera _camera;
    [SerializeField] private TilesController[] tiles;
    private int emptySpaceIndex = 8;

    [SerializeField]
    private SceneInfo sceneInfo;

    [SerializeField]
    private GameObject levelChanger;
    void Start()
    {
        _camera = Camera.main;
        Shuffle();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                Debug.Log(hit.transform.name);
                if (Vector2.Distance(a: emptySpace.position, b: hit.transform.position) < 3) {

                    Vector2 lastEmptyPosition = emptySpace.position;
                    TilesController thisTile = hit.transform.GetComponent<TilesController>();
                    emptySpace.position = thisTile.TragetPosition;
                    thisTile.TragetPosition = lastEmptyPosition;
                    int tileIndex = findIndex(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;
                }
            }

        }

        int correctTiles = 0;
        foreach (var a in tiles)
        {
            if (a != null)
            {
                if (a.inRightPlace)
                {
                    correctTiles++;
                }
            }
        }

        if (correctTiles == tiles.Length - 1)
        {
            sceneInfo.LobbyPuzzleCompleted = true;
            Invoke("ActivateFade", 4.0f);
            Invoke("LoadRooomScene", 5.0f);
        }


    }

    private void LoadRooomScene()
    {
        SceneManager.LoadScene("KidsRoom");
    }
    private void ActivateFade()
    {
        levelChanger.GetComponent<LevelChanger>().FadeToLevel();
    }
    public void Shuffle()
    {
        if(emptySpaceIndex != 8)
        {
            var tileOn8Pos = tiles[8].TragetPosition;
            tiles[8].TragetPosition = emptySpace.position;
            emptySpace.position = tileOn8Pos;
            tiles[emptySpaceIndex] = tiles[8];
            tiles[8] = null;
            emptySpaceIndex = 8;

        }

        int invertion;

        do
        {
            for (int i = 0; i <= 7; i++)
            {
                if (tiles[i] != null)
                {

                    var lastPos = tiles[i].TragetPosition;
                    int randomIndex = Random.Range(0, 7);
                    tiles[i].TragetPosition = tiles[randomIndex].TragetPosition;
                    tiles[randomIndex].TragetPosition = lastPos;
                    var tile = tiles[i];
                    tiles[i] = tiles[randomIndex];
                    tiles[randomIndex] = tile;
                }

            }
            invertion = GetInversion();
            Debug.Log("Puezzle Shuffle");
        }
        while (invertion%2 != 0);


    }

    public int findIndex(TilesController ts) {

        for (int i =  0; i < tiles.Length; i++) { 
            if (tiles[i] != null)
            {

                if (tiles[i] == ts)
                {
                    return i;
                }
            }
        
        }

        return -1;
    
    }

    int GetInversion() { 


        int inverserionSum= 0;
        for (int i = 0; i < tiles.Length; i++) {

            int thisTileInvertion = 0;
            for( int j=i; j< tiles.Length; j++)
            {

                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number) {

                        thisTileInvertion++;
                    }
                }
            }
        
            inverserionSum += thisTileInvertion;
        
        }
        return inverserionSum;
    }


}
