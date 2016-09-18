using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	private Slider slider;
	private AudioSource audiosource;
	private bool isEndOfLevel = false;
	private LevelManager lvlManager;
	private GameObject winLabel;

	public float lvlSeconds = 100;

	// Use this for initialization
	void Start () {
		
		lvlManager = GameObject.FindObjectOfType<LevelManager> ();
		slider = GetComponent<Slider> ();
		audiosource = GetComponent<AudioSource> ();


		FindYouWin ();
		winLabel.SetActive (false);


	}

	void FindYouWin(){
		winLabel = GameObject.Find ("You Win");

		if (!winLabel) {
			Debug.LogWarning ("Please create a You Win Object");
		}
	}
	
	// Update is called once per frame
	void Update () {

		slider.value = (Time.timeSinceLevelLoad / lvlSeconds);

		bool timeIsUp = (Time.timeSinceLevelLoad >= lvlSeconds);
		if (timeIsUp && !isEndOfLevel) {
			
			audiosource.Play ();
			winLabel.SetActive (true);

			Invoke ("LoadNextLevel", audiosource.clip.length);

			isEndOfLevel = true;

		}
	}

	void LoadNextLevel(){
		lvlManager.LoadNextLevel ();	
	}
}
