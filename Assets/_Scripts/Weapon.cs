using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	private Player player;
	private Collider2D coll;
	private float hitTimeFrame = .15f;
	private float hitTimer;
	private float thrustDirection = 20000f;
	public float ballThrust;

	void OnEnable()
	{
		hitTimer = hitTimeFrame;
		coll.enabled = true;
	}

	void OnDisable()
	{
		coll.enabled = false;
	}

	void Awake () 
	{
		player = GetComponentInParent<Player> ();
		coll = GetComponent<Collider2D> ();
	}

	void Update ()
	{
		if (hitTimer > 0) 
		{
			hitTimer -= Time.deltaTime;
		} 
		else 
		{
			this.gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			var thrust = thrustDirection;
			if (!player.characterController.IsFacingRight()) 
			{
				thrust *= -1f;
			} 

//			Debug.Log (other.gameObject.name + " just got KNOCK DA FUCK OUT! : " + thrust + " is the THRUST of the HIT!!!!");

			other.gameObject.GetComponent<Rigidbody2D> ().AddForce ((transform.right * thrust) + (transform.up * 0.3f), ForceMode2D.Force);
			other.GetComponent<Player> ().GetStunned ();

			Rigidbody2D ballRbody = other.gameObject.GetComponent<Rigidbody2D>();
			ballRbody.AddForce(transform.up * ballThrust);


		} else if (other.tag=="Ball"){

		}
	}
}
