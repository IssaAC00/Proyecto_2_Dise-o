using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyAudioManager : MonoBehaviour
{
  [SerializeField]
  private AudioClip movePiece;
  [SerializeField]
  private AudioClip finish;
  private AudioSource audioSource;
  // Start is called before the first frame update
  void Awake()
  {
    audioSource = GetComponent<AudioSource>();
  }

  public void PlayMove()
  {
    audioSource.PlayOneShot(movePiece);
  }

  public void PlayFinish()
  {
    audioSource.PlayOneShot(finish);
  }
}
