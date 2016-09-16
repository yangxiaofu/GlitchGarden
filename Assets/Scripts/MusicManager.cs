using UnityEngine;

using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	void Awake(){
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Don't destroy on load: " + name);
	}

	// Use this for initialization
	void Start () {	
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangeArray [level];

		if (thisLevelMusic) { // This there's some music attached. 
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}

	public void ChangeVolume(float volume){
		audioSource.volume = volume;
	}


}
