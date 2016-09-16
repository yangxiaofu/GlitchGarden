using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start(){
		if (autoLoadNextLevelAfter <= 0) {
			Debug.Log ("Level Auto Load Disabled.  use a positive number in seconds");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);	
		}
	}

	//Start the game
	public void GoToLevel(string name){
		SceneManager.LoadScene (name);
	}

	//Quit the game
	public void QuitGame(string name){
		Application.Quit ();
	}

	public void LoadScene(string name){
		SceneManager.LoadScene (name);
	}

	public void LoadNextLevel(){
		Debug.Log ("Loaded Scene is " + SceneManager.sceneCountInBuildSettings);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);

	}

}
