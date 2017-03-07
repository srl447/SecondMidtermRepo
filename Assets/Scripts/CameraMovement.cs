using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float verticalTurn = 0; //vertical camera movement
    //float horizontalTurn; //horizontal camera movement
    public float cameraSpeed = 1; //how fast the camera turns
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Cursor.visible = false; //turns off the mouse visibility
        Cursor.lockState = CursorLockMode.Locked; //keeps mouse cursor in place              
                                
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * cameraSpeed; //grabs vertical mouseinputs
        verticalTurn -= mouseY; //assigns value to verticalTurn
        //horizontalTurn = mouseX * Time.deltaTime * cameraSpeed; //assigns value to verticalTurn
        verticalTurn = Mathf.Clamp(verticalTurn, -80f, 80f);
        transform.eulerAngles = new Vector3(verticalTurn, transform.eulerAngles.y, 0f); //rotates camera
    }
}
