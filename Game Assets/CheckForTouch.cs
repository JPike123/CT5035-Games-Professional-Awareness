using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Placed as a component on the 'outer circle' of each of the joysticks.
/// </summary>
public class CheckForTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Joystick joystick;

    // Use this for initialization
    void Start()
    {
        //Gets the joystick script from the child object
        if (transform.childCount != 0)
        {
            joystick = transform.GetChild(0).GetComponent<Joystick>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        joystick.SetJoystickTouch(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystick.SetJoystickTouch(false);
    }
}
