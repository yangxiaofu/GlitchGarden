using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	private GameObject parent;
	private StarDisplay starDisplay;


	void Start(){
		parent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();

		if (!parent) {
			parent = new GameObject ("Defender");
		}
	}

	void OnMouseDown(){
		Vector2 rawPos = CalculateWorldPointOfMouseClick ();
		Vector2 roundedPos = SnapToGrid (rawPos);
		GameObject defender = Button.selectedDefender;

		int defenderCost = defender.GetComponent<Defender>().StarCost;

		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (roundedPos, defender);			
		}else {
			Debug.Log ("Insufficient Stars to Spawn");
		}
	}

	Vector2 SnapToGrid(Vector2 rawWorldPosition){
		float newX = Mathf.RoundToInt (rawWorldPosition.x);
		float newY = Mathf.RoundToInt (rawWorldPosition.y);
		return new Vector2 (newX, newY);
	}

	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);
		return worldPos;
	}

	void SpawnDefender(Vector2 roundedPos, GameObject defender){
		if (Button.selectedDefender != null) {

			GameObject spawnedDefender = Instantiate (defender, roundedPos, Quaternion.identity) as GameObject;
			spawnedDefender.transform.parent = parent.transform;
		}
	}
}
