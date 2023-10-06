using UnityEngine;

public class LevelChanger : MonoBehaviour
{
  [SerializeField]
  private Animator animator;
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      FadeToLevel();
    }
  }
  public void FadeToLevel()
  {
    animator.SetTrigger("FadeOut");
  }


}
