using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;

	private Animator anim;

	[Range (-1f, 1.5f)] 
	public float currentSpeed;

	private GameObject currentTarget;

	// Use this for initialization
	void Start () {
		//Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);

		if (!currentTarget) {
			anim.SetBool ("IsAttacking", false);
		}

	}

	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log(name + "trigger enter");
	}

	public void SetSpeed(float speed){
		currentSpeed = speed;
	}

	public void StrikeCurrentTarget(float damage){

		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health> ();
			if (health) {
				health.DealDamage (damage);
			}
		}

	}

	public void Attack(GameObject obj){
		currentTarget = obj;
	}
}
