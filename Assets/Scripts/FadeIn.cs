using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public float fadeInTimeInSeconds;

	private Image fadePanel;
	private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image> ();


	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeSinceLevelLoad < fadeInTimeInSeconds) { //Fade In
			
			//Fade In
			float alphaChange = Time.deltaTime / fadeInTimeInSeconds;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;

		} else {
			//Deactivate the panel
			gameObject.SetActive(false);
		}
	
	}
}
