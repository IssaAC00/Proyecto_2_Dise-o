using Unity.VisualScripting;
using UnityEngine;

public class GearController : MonoBehaviour
{
    [SerializeField] private int gearType;

    [Header("Object Components")]
    private SpriteRenderer sprite;
    private Rigidbody2D body;
    private Animator animator;

    [Header("Drag and Drop")]
    private Vector3 defaultPosition;
    private bool beingDragged;
    private Color draggedColor;

    [Header("Placement")]
    public PinController selectedPin = null;
    public bool onEmptySpace = true;
    public bool isPlaced = false;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        defaultPosition = transform.position;
        draggedColor = new Color(1f, 1f, 1f, 0.5f);
    }

    void Update()
    {
        if (beingDragged)
        {
            if (isPlaced) //Player moved a gear already placed
            {
                isPlaced = false;
                selectedPin.gear = null;
                animator.SetBool("IsConnected", false);
            }
            sprite.color = draggedColor;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);
        }
        else
        {
            sprite.color = Color.white;
            //Check is the position is valid
            if (selectedPin != null && onEmptySpace)
            {
                isPlaced = true;
                selectedPin.gear = this;
                transform.position = selectedPin.transform.position;
            }
            else
                transform.position = defaultPosition;
        }
    }

    public void OnMouseDown()
    {
        beingDragged = true;
    }

    public void OnMouseUp()
    {
        beingDragged = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!isPlaced)
        {
            if (other.gameObject.CompareTag("Pin"))
            {
                selectedPin = other.GetComponent<PinController>();
            }
            else if (other.gameObject.CompareTag("Gear"))
            {
                onEmptySpace = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!isPlaced)
        {
            if (other.gameObject.CompareTag("Pin"))
            {
                selectedPin = null;
            }
            else if (other.gameObject.CompareTag("Gear"))
            {
                onEmptySpace = true;
            }
        }
    }

    public int GetGearType()
    {
        return gearType;
    }

    public void Animation_SetRotation(bool rotation)
    {
        animator.SetBool("RotatesClockwise", rotation);
    }

    public void Animation_SetConnect(bool connected)
    {
        animator.SetBool("IsConnected", connected);
    }
}
