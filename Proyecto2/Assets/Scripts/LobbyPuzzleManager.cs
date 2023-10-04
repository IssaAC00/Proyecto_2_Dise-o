using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyPuzzleManager : MonoBehaviour
{
  [SerializeField]
  private Transform gameTransform;
  [SerializeField]
  private Transform piecePrefab;
  private int emptyLocation;
  public int size = 3;
  private List<Transform> pieces;
  private bool playing;

  // Crea las piezas del puzzle a partir de una imagen
  // La hace cuadricula
  private void CreateGamePieces(float gapThickness)
  {
    float width = 1 / (float)size;

    for (int row = 0; row < size; row++)
    {
      for (int col = 0; col < size; col++)
      {
        Transform piece = Instantiate(piecePrefab, gameTransform);
        pieces.Add(piece);

        // Pieces will be in the Gameboard from -1 to 1?
        piece.localPosition = new Vector3(-1 + (2 * width * col) + width,
                                          +1 - (2 * width * row) - width,
                                          0);
        piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
        piece.name = $"{(row * size) + col}";
        // Empty space at bottom right
        if ((row == size - 1) && (col == size - 1))
        {
          emptyLocation = (size * size) - 1;
          piece.gameObject.SetActive(false);
        }
        else
        {
          float gap = gapThickness / 2;
          Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
          Vector2[] uv = new Vector2[4];

          // UV coord order: (0, 1), (1, 1), (0, 0), (1, 0)
          uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
          uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
          uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
          uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));

          // Apply the new UV to the mesh
          mesh.uv = uv;

        }
      }
    }
  }


  private bool SwapIfValid(int i, int offset, int colCheck)
  {
    if (((i % size) != colCheck) && ((i + offset) == emptyLocation))
    {
      // Swap them in game State
      (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);
      // Swap the Transforms
      (pieces[i].localPosition, pieces[i + offset].localPosition) = (pieces[i + offset].localPosition, pieces[i].localPosition);
      // Update Empty Location
      emptyLocation = i;
      return true;
    }
    return false;
  }

/*
  private IEnumerator WaitShuffle(float duration)
  {
    yield return new WaitForSeconds(duration);
    Shuffle();
    shuffling = false;
  }
*/

  private void Shuffle()
  {
    int count = 0;
    int last = 0;
    while (count < (size * size * size))
    {
      // Pick a random location
      int rnd = Random.Range(0, size * size);
      // Only thing we forbid is undoing the last move
      if (rnd == last) { continue; }
      last = emptyLocation;
      // Try surrounding spaces looking for valid move
      if (SwapIfValid(rnd, -size, size))
      {
        count++;
      }
      else if (SwapIfValid(rnd, +size, size))
      {
        count++;
      }
      else if (SwapIfValid(rnd, -1, 0))
      {
        count++;
      }
      else if (SwapIfValid(rnd, +1, size - 1))
      {
        count++;
      }
    }
  }

  private bool CheckCompletion()
  {
    for (int i = 0; i < pieces.Count; i++)
    {
      if (pieces[i].name != $"{i}")
      {
        return false;
      }
    }
    return true;
  }

  // Start is called before the first frame update
  void Start()
  {
    pieces = new List<Transform>();
    CreateGamePieces(0.01f);
    Shuffle();
    playing = true;
  }

  // Update is called once per frame
  void Update()
  {
    /*
    // Check for completion
    if (!shuffling && CheckCompletion())
    {
      shuffling = true;
      StartCoroutine(WaitShuffle(0.5f));
    }
    */
    if (playing && CheckCompletion())
    {
      Debug.Log("CONSEGUIDO!");
      playing = false;
    }


    if (Input.GetMouseButtonDown(0))
    {
      RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
      if (hit)
      {
        for (int i = 0; i < pieces.Count; i++)
        {
          if (pieces[i] == hit.transform)
          {
            if (SwapIfValid(i, -size, size)) { break; }
            if (SwapIfValid(i, size, size)) { break; }
            if (SwapIfValid(i, -1, 0)) { break; }
            if (SwapIfValid(i, +1, size - 1)) { break; }
          }
        }
      }
    }

  }

}