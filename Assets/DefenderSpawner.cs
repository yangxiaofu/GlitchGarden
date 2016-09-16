using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject parent;

	void Start(){
		parent = GameObject.Find ("Defenders");

		if (!parent) {
			parent = new GameObject ("Defender");
		}
	}

	void OnMouseDown(){
		Vector2 rawPos = CalculateWorldPointOfMouseClick ();
		Vector2 roundedPos = SnapToGrid (rawPos);

		if (Button.selectedDefender != null) {
			GameObject defender = Instantiate (Button.selectedDefender, roundedPos, Quaternion.identity) as GameObject;
			defender.transform.parent = parent.transform;
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
}
