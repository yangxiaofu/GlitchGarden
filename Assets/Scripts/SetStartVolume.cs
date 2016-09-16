﻿using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicManager;


	// Use this for initialization
	void Start () {

		musicManager = GameObject.FindObjectOfType<MusicManager> ();
	
		if (musicManager) {
			
			float volume = PlayerPrefsManager.GetMasterVolume ();

			musicManager.ChangeVolume (volume);

		} else {
			Debug.LogWarning ("Music Manager not found in scene");
		}
			


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
