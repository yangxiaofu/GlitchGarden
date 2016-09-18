using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;

	private Button[] buttonArray;
	public static GameObject selectedDefender;

	private Text costText;


	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button> ();

		costText = GetComponentInChildren<Text> ();

		if (!costText) {Debug.LogWarning (name + "Has no cost text");}


		costText.text = defenderPrefab.GetComponent<Defender> ().StarCost.ToString ();




	}
	
	void OnMouseDown(){
		
		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		}

		GetComponent<SpriteRenderer> ().color = Color.white;

		selectedDefender = defenderPrefab;

	}
}
