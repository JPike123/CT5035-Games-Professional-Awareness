using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Currently only allows one joystick to be used at a time.
/// Inherited by the 'inner circle' of the joystick depending on whether it's used for rotation or movement.
/// </summary>
public class Joystick : MonoBehaviour {

    [SerializeField]
    Transform player;

    [SerializeField]
    int speed = 5;

    RectTransform joystickTransform;

    bool joystickTouch;

    Vector2 pointA, pointB;
    Vector2 center;
    
    //This is how far away the inner circle can move from the center of the outer circle.   
    //Needs to be altered depending on how big the outer circle is.
    //(Measured by local position)
    const int DISTANCE_FROM_CENTER = 38;

    //Whether or not the inner circle is within bounds
    bool isOutOfBounds;

    //Used to get the center of the joystick, as well as the starting position of the joystick
    protected void SetUpJoystick()
    {
        joystickTransform = GetComponent<RectTransform>();
        center = GetComponent<RectTransform>().position;
    }

    protected RectTransform GetJoystickTransform()
    {
        return joystickTransform;
    }

    protected int GetSpeed()
    {
        return speed;
    }

    protected Transform GetPlayer()
    {
        return player;
    }

    protected bool GetJoystickTouch()
    {
        return joystickTouch;
    }

    //Finds which direction the joystick is moving (up, down, left, or right)
    protected Vector2 FindJoystickDirection()
    {
        pointB = joystickTransform.localPosition;

        Vector2 offset = pointB - pointA;
        //clamps it to be able to be used as a direction
        Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

        return direction;
    }

    //Makes sure the joystick doesn't go out of the allowed area
    protected void CheckInBounds(Vector2 joystickPos)
    {
        Vector2 distanceFromCenter = joystickPos - center;
        distanceFromCenter = Vector2.ClampMagnitude(distanceFromCenter, DISTANCE_FROM_CENTER);
        joystickTransform.position = center + distanceFromCenter;
    }

    //Used by the CheckForTouch script to determine whether or not the joystick is currently being used.
    public void SetJoystickTouch(bool isJoystickTouch)
    {
        joystickTouch = isJoystickTouch;

        if (joystickTouch)
        {
            pointA = joystickTransform.localPosition;
        }
        else
        {
            joystickTransform.localPosition = Vector2.zero;
        }
    }
}
