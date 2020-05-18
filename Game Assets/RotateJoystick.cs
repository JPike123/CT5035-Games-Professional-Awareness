using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateJoystick : Joystick
{
    // Use this for initialization
    void Start()
    {
        SetUpJoystick();
    }

    void FixedUpdate()
    {
        //if the joystick is being touched, make sure the input is still in bounds, before rotating the player in the correct direction
        if (GetJoystickTouch())
        {
            CheckInBounds(Input.mousePosition);

            RotateCharacter(FindJoystickDirection());
        }
    }

    //Rotates the player in the direction provided
    void RotateCharacter(Vector2 direction)
    {
        //Converts the Vector2 used fo the joystick UI into a vector3, as well as making sure that the Z stays as 0.
        Vector3 convertedToVector3 = new Vector3(-direction.y, direction.x, 0);

        //Alters the players rotation using eulerAngles
        GetPlayer().eulerAngles += convertedToVector3 * GetSpeed() * Time.deltaTime;
    }
}
