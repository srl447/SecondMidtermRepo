using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {


    Collider door; //Collider to assign to doors later
    public LayerMask doorMask; // Allows for the ray to only detect keys
    bool clicked;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //checks to see input from mouse button 1
        {
            clicked = true; //stores the input here to use in Fixed Update
        }
        else
        {
            clicked = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // creates a ray

        RaycastHit rayHit = new RaycastHit(); //creates variable to store ray data

        Debug.DrawRay(ray.origin, ray.direction * 5f, Color.yellow); // draws raycast in the editor

        if (Physics.Raycast(ray, out rayHit, 5f, doorMask)) //stores data in rayHit if a door is within 5 units of it
        {
            door = rayHit.collider; //stores the key's collider in the collider variable

            // Checks to see if you have matching key to the door you look at to see if text should be displayed 
            if ((door.gameObject.tag == "Door1" && GameManager.hasKeyOne == true) || (door.gameObject.tag == "Door2" && GameManager.hasKeyTwo == true) || (door.gameObject.tag == "Door3" && GameManager.hasKeyThree == true))
            {
                KeyText.displayDoorText = true; //Changes a variable in the text script to tell it to turn text on
            }
            //If they click and they have the right key for the right door, it rotates 90 degrees and then the collider gets removed
            // so you can't keep rotating it. I either need to add another that won't trigger the rotation or find a better way. 
            if (clicked) //checks to see input from mouse button 1 from Update
            {
                if (door.gameObject.tag == "Door1" && GameManager.hasKeyOne == true)
                {
                    DoorSwing(); //calls DoorSwing function
                }
                if (door.gameObject.tag == "Door2" && GameManager.hasKeyTwo == true)
                {
                    DoorSwing();
                }
                if (door.gameObject.tag == "Door3" && GameManager.hasKeyThree == true)
                {
                    DoorSwing();
                }

            }
        }
        else
        {
            KeyText.displayDoorText = false; //Changes a variable in the text script to tell it to turn text off
        }
    }

    void DoorSwing()
    {
        door.gameObject.transform.Rotate(0f, -90f, 0f); //rotates the door
        Destroy(door.gameObject.GetComponent<MeshCollider>()); //removes the collider so the function can't be run on the same door twice
        KeyText.displayDoorText = false;//Changes a variable in the text script to tell it to turn text off
    }
}
