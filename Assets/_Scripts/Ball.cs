using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private SpriteRenderer sRenderer;
	public Collider2D coll;
	public Collider2D trigger;
	private Rigidbody2D rBody;

	public bool canScore = false;
	public bool isVisibe = false;
	public bool canBePickedUp = true;

	private float ballCanBePickedUpTime = 1f;
	private float ballTimer;

	public Player playerInPossession;

	void Awake () 
	{
		sRenderer = GetComponentInChildren<SpriteRenderer> ();
//		coll = GetComponent<Collider2D> ();
//		trigger = GetComponentInChildren<Collider2D> ();
		rBody = GetComponent<Rigidbody2D> ();
	}

	void Start()
	{
		ShowBall ();
	}
	
	void Update () 
	{
		if (playerInPossession != null)
		{
			if (playerInPossession.isStunned)
			{
				DropBall (playerInPossession);
			}
		}

		if (ballTimer > 0) 
		{
			ballTimer -= Time.deltaTime;
		} 
		else 
		{
			canBePickedUp = true;
		}
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" || canBePickedUp)
		{
			var player = other.gameObject.GetComponent<Player> ();
			PickupBall (player);
		}
	}

	public void DisappearBall()
	{
		isVisibe = false;
		canBePickedUp = false;
		sRenderer.enabled = isVisibe;
		trigger.enabled = isVisibe;
	}

	public void ShowBall()
	{
		canBePickedUp = false;
		ballTimer = ballCanBePickedUpTime;

		isVisibe = true;
		sRenderer.enabled = isVisibe;
		trigger.enabled = isVisibe;
	}

	public void PickupBall(Player player)
	{
		if (player != null)
		{
			canBePickedUp = false;
			playerInPossession = player;
			playerInPossession.hasBall = true;
			canScore = true;
			DisappearBall ();
		}


//		this.transform.parent = player.transform;
//		this.transform.position = transform.parent.position;
	}

	public void DropBall(Player player)
	{
		canBePickedUp = false;
		playerInPossession.hasBall = false;
		playerInPossession = null;
		canScore = false;

		this.transform.position = player.transform.position + transform.right;
		rBody.AddForce (transform.right * 5);

		ShowBall ();
	}

	public void PassBall(Player player)
	{
		canBePickedUp = false;
		playerInPossession = player;
		playerInPossession.hasBall = true;
//		this.transform.parent = player.transform;
	}



}
