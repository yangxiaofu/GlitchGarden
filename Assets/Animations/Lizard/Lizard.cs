using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {

	// Use this for initialization
	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		attacker = GetComponent<Attacker> ();
	}
		
	void OnTriggerEnter2D(Collider2D col){
		
		GameObject obj = col.gameObject;

		//Abort or leave the method if not colliding with a defender
		if (!obj.GetComponent<Defender> ()) {
			return;
		}

		Debug.Log (name + " collided with " + col.gameObject);

		//Called at the time of the actual blow
		if (obj.GetComponent<Stone> ()) {
			anim.SetBool ("IsAttacking", true);
			attacker.Attack (obj);
		}

		if (obj.GetComponent<Cactus> ()) {
			anim.SetBool ("IsAttacking", true);
			attacker.Attack (obj);
		}

		if (obj.GetComponent<Gnome>()){
			anim.SetBool ("IsAttacking", true);
			attacker.Attack(obj);
		}
			

	}
}
