using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{

    Collider key; //Collider to assign to keys later
    public LayerMask keyMask; // Allows for the ray to only detect keys
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
	void FixedUpdate ()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // creates a ray
        RaycastHit rayHit = new RaycastHit(); //creates variable to store ray data

        Debug.DrawRay(ray.origin, ray.direction * 5f, Color.yellow); // draws raycast in the editor

        if (Physics.Raycast(ray, out rayHit, 5f, keyMask)) //stores data in rayHit if a key is within 5 units of it
        {
            KeyText.displayKeyText = true; //Changes a variable in the text script to tell it to turn text on
            key = rayHit.collider; //stores the key's collider in the collider variable
            if (clicked) //checks to see input from mouse button 1 from Update
            {

                //Checks what keys have been picked up and assigns the variable for holding that key to true
                if(key.gameObject.tag == "Key1")
                {
                    GameManager.hasKeyOne = true; 
                }
                if (key.gameObject.tag == "Key2")
                {
                    GameManager.hasKeyTwo = true; 
                }
                if (key.gameObject.tag == "Key3")
                {
                    GameManager.hasKeyThree = true;
                    
                }

                Destroy(key.gameObject); //removes the key from the world
                KeyText.displayKeyText = false;//Changes a variable in the text script to tell it to turn text off
            }    
        }
        else
        {
            KeyText.displayKeyText = false; //Changes a variable in the text script to tell it to turn text off
        }
    }
}
