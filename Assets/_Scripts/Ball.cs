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
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			var player = other.gameObject.GetComponent<Player> ();
			PickupBall (player);
		}
	}

	public void DisappearBall()
	{
		isVisibe = false;
		sRenderer.enabled = isVisibe;
		coll.enabled = isVisibe;
	}

	public IEnumerator ShowBall()
	{
		isVisibe = true;
		sRenderer.enabled = isVisibe;

		var timeToWait = 0.3f;

		yield return new WaitForSecondsRealtime (timeToWait);
		coll.enabled = isVisibe;
	}

	public void PickupBall(Player player)
	{
		playerInPossession = player;
		playerInPossession.hasBall = true;
		canScore = true;
		DisappearBall ();

//		this.transform.parent = player.transform;
//		this.transform.position = transform.parent.position;
	}

	public void DropBall(Player player)
	{
		playerInPossession.hasBall = false;
		playerInPossession = null;
		canScore = false;

		this.transform.position = player.transform.position;
		rBody.AddForce (Vector2.right * (Random.Range(-1,1) * 3));

		StartCoroutine(ShowBall ());
	}

	public void PassBall(Player player)
	{
		playerInPossession = player;
		playerInPossession.hasBall = true;
//		this.transform.parent = player.transform;
	}



}
