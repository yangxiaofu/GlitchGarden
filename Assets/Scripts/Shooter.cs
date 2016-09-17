using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject gun;


	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Start(){

		animator = GameObject.FindObjectOfType<Animator> ();


		projectileParent = GameObject.Find ("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles");
		}


		SetMyLaneSpawner ();
		print (myLaneSpawner);
	}

	void Update(){
		if (animator != null) {
			if (IsAttackerAheadInLane ()) {

				animator.SetBool ("IsAttacking", true);
			} else {
				animator.SetBool ("IsAttacking", false);
			}
		}


	}

	//Look through all spawners and set MyLaneSpawner if found.
	void SetMyLaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError (name + " can't find spawner in lane");
	}


	bool IsAttackerAheadInLane(){
		// Exit if no attackers in the lane.
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}

		//If there are attackers, are they ahead
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}

		return false;
	}

	private void FireGun(){
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}






}
