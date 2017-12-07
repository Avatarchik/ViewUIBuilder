using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEvent: MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public delegate void MyDelegate(PointerEventData data);
    public MyDelegate myDelegateUp;
    public MyDelegate myDelegateDown;
    public MyDelegate myDelegateDeactivate;

    public delegate void DisabledDelegate();
    public DisabledDelegate OnDisabledDelegate;

    public bool disabled;

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!disabled)
            myDelegateUp(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!disabled)
            myDelegateDown(eventData);
        else if (OnDisabledDelegate != null)
            OnDisabledDelegate();
    }

    public void Click()
    {
        if (!disabled)
        {
            myDelegateDown(null);
            myDelegateUp(null);
        }
    }

    public void deactivate()
    {
        myDelegateDeactivate(null);
    }
}
