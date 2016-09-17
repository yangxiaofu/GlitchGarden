using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	private StarDisplay starDisplay;
	public int StarCost = 10;

	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
	}

	// Only being used as a tag for now. 
	public void AddStars(int amount){
		starDisplay.AddStars (amount);
	}
	
}
