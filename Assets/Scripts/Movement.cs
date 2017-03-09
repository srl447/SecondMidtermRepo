using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController characterControl; //makes character controller
    Vector3 movementDirection; //direction for where the character moves
    public float speed = 1; //how fast the character moves
    public float camSpeed = 1; //camera speed for horizontal
    float relativeHorizontal; //horizontal movement relative to the player
    float relativeVertical;//vertical movement relative to the player
    float angle;//angle the player is at in radians
	void Start ()
    {
        characterControl = GetComponent<CharacterController>(); //assigns the character controller
	}
	
	void Update ()
    {
        //sets a bunch of variables to use for math
        angle = (transform.eulerAngles.y + 90) * Mathf.PI / 180; //assigns the rotation to angle. Converts angle from degrees to radians
        //the + 90 is to account for the linear algebra creating rotated controls
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //Gets horizontal inputs from a/d and left/right arrows keys
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime; //Gets vertical inputs from w/s and up/down arrow keys
        float mouseX = Input.GetAxis("Mouse X"); //Gets horizontal mouse movements

        //Adjusts movement direction to be relative to the character direction not the unity world
        //This is complex linear algebra that I'm not 100% sure on, but I kinda know
        if (angle >= 0)
        {
            relativeHorizontal =  horizontal * Mathf.Sin(angle) - vertical * Mathf.Cos(angle); // sets horizontal vector component
            relativeVertical  =  horizontal * Mathf.Cos(angle) + vertical * Mathf.Sin(angle); //sets vertical vector component
        }
        // accounts for a weird case where a negative angle would occur
        else
        {
            relativeHorizontal = horizontal * Mathf.Sin(angle) + vertical * Mathf.Cos(angle);
            relativeVertical = - horizontal * Mathf.Cos(angle) + vertical * Mathf.Sin(angle);
        }
        if (vertical != 0 && horizontal != 0) //stops speed from doubling when moving diaganolly
        {
            relativeHorizontal = relativeHorizontal * .75f;
            relativeVertical = relativeVertical * .75f;
        }
        movementDirection = new Vector3(relativeHorizontal, -.2f, relativeVertical); //assigns inputs in a vector

        characterControl.Move(movementDirection); //uses the character controller to move
        // rotates the figure to simulate the rotated camera while tracking rotation in the transform
        transform.Rotate(0f, mouseX * Time.deltaTime * camSpeed, 0f);
        
    }
}
