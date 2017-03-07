using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRoomAudio : MonoBehaviour {
    AudioSource roomPlayer;
	// Use this for initialization
	void Start ()
    {
        roomPlayer = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider coll)
    {
        roomPlayer.Play();
    }
    void OnTriggerExit(Collider coll)
    {
        roomPlayer.Pause();
    }
}
