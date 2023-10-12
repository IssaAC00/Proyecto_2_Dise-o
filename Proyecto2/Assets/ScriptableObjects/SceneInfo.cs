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

  [SerializeField]
  private bool lobbyLetterRead;
  public bool LobbyLetterRead
  {
    get { return lobbyLetterRead; }
    set { lobbyLetterRead = value; }
  }
    [SerializeField]
    private bool kitchenPuzzleCompleted = false;
    public bool KitchenPuzzleCompleted
    {
        get { return kitchenPuzzleCompleted; }
        set { kitchenPuzzleCompleted = value; }
    }
    private Vector2 playerKitchenPos;
  public Vector2 PlayerKitchenPos
  {
    get { return playerKitchenPos; }
    set { playerKitchenPos = value; }
  }
    private Vector2 playeKidsRoomPos;
    public Vector2 PlayeKidsRoomPos
    {
        get { return playeKidsRoomPos; }
        set { playeKidsRoomPos = value; }
    }

    [SerializeField]
    private bool kidsRoomPuzzleCompleted = false;
    public bool KidsRoomPuzzleCompleted
    {
        get { return kidsRoomPuzzleCompleted; }
        set { kidsRoomPuzzleCompleted = value; }
    }

    [SerializeField]
    private bool roomLetterRead;
    public bool RoomLetterReadS
    {
        get { return roomLetterRead; }
        set { roomLetterRead = value; }
    }

}
