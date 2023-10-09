using UnityEngine;

public class LevelChanger : MonoBehaviour
{
  [SerializeField]
  private Animator animator;
  public void FadeToLevel()
  {
    animator.SetTrigger("FadeOut");
  }


}
