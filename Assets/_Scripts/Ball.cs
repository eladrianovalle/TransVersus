using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private SpriteRenderer sRenderer;
	private Collider2D coll;
	private Rigidbody2D rBody;

	public bool canScore = false;
	public bool isVisibe = false;

	public Player playerInPossession;

	void Awake () 
	{
		sRenderer = GetComponentInChildren<SpriteRenderer> ();
		coll = GetComponent<Collider2D> ();
		rBody = GetComponent<Rigidbody2D> ();
	}

	void Start()
	{
		ShowBall (true);
	}
	
	void Update () 
	{
		if (playerInPossession.isAttacking)
		{
			DropBall ();
		}

//		if (isVisibe) 
//		{
//			ShowBall (true);
//		} 
//		else 
//		{
//			ShowBall (false);
//		}
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			var player = other.gameObject.GetComponent<Player> ();
			PickupBall (player);
		}
	}

	public void ShowBall(bool showBall)
	{
		isVisibe = showBall;
		sRenderer.enabled = isVisibe;
		coll.enabled = isVisibe;
		rBody.isKinematic = !isVisibe;
	}

	public void PickupBall(Player player)
	{
		ShowBall (false);
		playerInPossession = player;
		this.transform.parent = player.transform;
		this.transform.position = transform.parent.position;
	}

	public void DropBall()
	{
		playerInPossession = null;
		this.transform.position = transform.parent.position;
		this.transform.parent = null;
		ShowBall (true);
	}

	public void PassBall(Player player)
	{
		playerInPossession = player;
		this.transform.parent = player.transform;
	}



}
