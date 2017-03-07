using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyText : MonoBehaviour {

    Text keyText; //Creates Text 
    public static bool displayKeyText; // Creates variable that other scripts will change to display key text
    public static bool displayDoorText; // Creates variable that other scripts will change to display door text
    // Use this for initialization
    void Start ()
    {
        keyText = GetComponent<Text>(); //Assings Text
	}
	
	// Update is called once per frame
	void Update () {
		if (displayKeyText) //checks if it should display the Key text
        {
            keyText.text = "Click to pickup key"; //changes the text
        }
        else if (displayDoorText) //same but for doors
        {
            keyText.text = "Click to open door"; 
        }
        else
        {
            keyText.text = " "; //resets the text to nothing
        }
	}
}
