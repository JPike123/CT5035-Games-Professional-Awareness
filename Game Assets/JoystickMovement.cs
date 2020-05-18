using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour {
    
    [SerializeField]
    Transform player;

    [SerializeField]
    float speed = 5.0f;

    private bool touchStart = false;
    private Vector2 pointA, pointB;

    [SerializeField]
    Transform innerCircle;

    [SerializeField]
    Transform outerCircle;


	// Use this for initialization
	void Start () {
        
	}


    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {

            //innerCircle.transform.position = pointA;
            //outerCircle.transform.position = pointA;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            innerCircle.transform.localPosition = Vector2.zero;
            touchStart = false;
        }
    }

    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            //clamps it to be able to be used as a direction
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

            moveCharacter(direction);

            //innerCircle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
            innerCircle.transform.position = new Vector2(innerCircle.transform.position.x + direction.x, innerCircle.transform.position.y + direction.y);

        }
    }

    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}
