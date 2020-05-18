using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Placed on the 'inner circle' of the joystick.
/// Joystick script for moving the player.
/// </summary>
public class MoveJoystick : Joystick
{

	// Use this for initialization
	void Start () {
        SetUpJoystick();
	}

    void FixedUpdate()
    {
        //if the joystick is being touched, make sure the input is still in bounds, before moving the player in the correct direction
        if (GetJoystickTouch())
        {
            CheckInBounds(Input.mousePosition);            

            MoveCharacter(FindJoystickDirection());            
        }
    }

    //Moves the character in the direction given
    void MoveCharacter(Vector2 direction)
    {
        //Converts the Vector2 of the joystick UI into a Vector3
        Vector3 convertedToVector3 = new Vector3(direction.x, 0, direction.y);

        //Allows for each of the directions to add to the movement vector
        Vector3 movementToBeAdded = Vector3.zero;

        //UP
        if (convertedToVector3.z <= 1 && convertedToVector3.z > 0 && convertedToVector3.x > -0.9f && convertedToVector3.x < 0.9f)
        {
            Vector3 forwardMovement = new Vector3(GetPlayer().forward.x, 0, GetPlayer().forward.z);

            movementToBeAdded += forwardMovement;
        }

        ////BACK
        if (convertedToVector3.z >= -1 && convertedToVector3.z < 0 && convertedToVector3.x > -0.9f && convertedToVector3.x < 0.9f)
        {
            Vector3 backMovement = new Vector3(-GetPlayer().forward.x, 0, -GetPlayer().forward.z);

            movementToBeAdded += backMovement;
        }

        //RIGHT
        if (convertedToVector3.x <= 1 && convertedToVector3.x > 0 && convertedToVector3.z > -0.9f && convertedToVector3.z < 0.9f)
        {
            Vector3 rightMovement = new Vector3(GetPlayer().right.x, 0, GetPlayer().right.z);

            movementToBeAdded += rightMovement;
        }

        //LEFT
        if (convertedToVector3.x >= -1 && convertedToVector3.x < 0 && convertedToVector3.z > -0.9f && convertedToVector3.z < 0.9f)
        {
            Vector3 leftMovement = new Vector3(-GetPlayer().right.x, 0, -GetPlayer().right.z);
            Debug.Log("left");
            movementToBeAdded += leftMovement;
        }
        
        //Makes sure going diagonally doesn't double the speed of the player
        movementToBeAdded.Normalize();

        GetPlayer().position += movementToBeAdded * GetSpeed() * Time.deltaTime;
    }
}
