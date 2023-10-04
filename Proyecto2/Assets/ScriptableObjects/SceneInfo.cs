using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SceneInfo", menuName ="Persistence")]
public class SceneInfo : ScriptableObject
{
  [SerializeField]
  private Vector2 playerLobbyPos;
  public Vector2 PlayerLobbyPos
  {
    get { return playerLobbyPos; }
    set { playerLobbyPos = value; }
  }
  
}
