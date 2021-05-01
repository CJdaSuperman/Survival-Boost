using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject SpaceShip;

    public bool PointerDown { get; set; }

    public UnityEvent onHold;
    public UnityEvent onRelease;

    public void OnPointerDown(PointerEventData eventData) { PointerDown = true; }

    public void OnPointerUp(PointerEventData eventData) { PointerDown = false; }

    void Update()
    {
        if(PointerDown)
        {
            if(onHold != null)
                onHold.Invoke();
        }
        else
        {
            if (onRelease != null)
                onRelease.Invoke();
        }
    }
}
