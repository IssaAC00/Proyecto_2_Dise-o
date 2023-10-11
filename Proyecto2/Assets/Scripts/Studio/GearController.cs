using UnityEngine;
using UnityEngine.EventSystems;

public class GearController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private int gearType;
    private SpriteRenderer sprite;
    private Vector3 defaultPosition;

    private PinController selectedPin = null;
    private bool validPosition = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        defaultPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        sprite.color = new Color(1f,1f,1f,0.5f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        sprite.color = Color.white;
        if(selectedPin != null && validPosition)
        {
            selectedPin.gear = this;
            transform.position = selectedPin.transform.position;
        }
        else
            transform.position = defaultPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Pin")
        {
            selectedPin = other.GetComponent<PinController>();
        }
        else if(other.gameObject.tag == "Gear")
        {
            validPosition = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Pin")
        {
            selectedPin = null;
        }
        else if(other.gameObject.tag == "Gear")
        {
            validPosition = true;
        }
    }

    public int GetGearType()
    {
        return gearType;
    }
}
