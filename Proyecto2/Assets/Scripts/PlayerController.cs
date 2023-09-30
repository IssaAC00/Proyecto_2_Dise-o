using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  private float movementSpeed = 4f;
  private float collisionOffset = 0.01f;
  public ContactFilter2D movementFilter;
  private Vector2 movementInput;
  private Rigidbody2D rb;
  private List<RaycastHit2D> castCollision = new List<RaycastHit2D>();
  // Start is called before the first frame update
  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    // if no input: IDLE
    if (movementInput != Vector2.zero)
    {
      bool success = TryMove(movementInput);
      if (!success)
      {
        success = TryMove(new Vector2(movementInput.x, 0));
        if (!success)
        {
          success = TryMove(new Vector2(0, movementInput.y));
        }
      }
    }
  }

  private bool TryMove(Vector2 direction)
  {
    int count = rb.Cast(
      direction,
      movementFilter,
      castCollision,
      movementSpeed * Time.fixedDeltaTime + collisionOffset
    );
    if (count == 0)
    {
      rb.MovePosition(rb.position + direction * movementSpeed * Time.fixedDeltaTime);
      return true;
    }
    else
    {
      return false;
    }
    
  }

  void OnMove(InputValue movementValue)
  {
    movementInput = movementValue.Get<Vector2>();
  }

}