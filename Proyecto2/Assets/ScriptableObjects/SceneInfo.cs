using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SceneInfo", menuName ="Persistence")]
public class SceneInfo : ScriptableObject
{
  private Vector2 playerLobbyPos;
  public Vector2 PlayerLobbyPos
  {
    get { return playerLobbyPos; }
    set { playerLobbyPos = value; }
  }
  
  [SerializeField]
  private bool lobbyPuzzleCompleted = false;
  public bool LobbyPuzzleCompleted
  {
    get { return lobbyPuzzleCompleted; }
    set { lobbyPuzzleCompleted = value; }
  }
  
}
