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
		if (playerInPossession != null)
		{
			if (playerInPossession.isStunned)
			{
				DropBall ();
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

	public IEnumerator ShowBall(bool showBall)
	{
		isVisibe = showBall;
		sRenderer.enabled = isVisibe;
		rBody.enabled = !isVisibe;

		var timeToWait = 0.0f;
		if (!isVisibe) {timeToWait = 1f;}
		yield return new WaitForSecondsRealtime (timeToWait);
		coll.enabled = isVisibe;
	}

	public void PickupBall(Player player)
	{
		StartCoroutine(ShowBall (false));
		playerInPossession = player;
		this.transform.parent = player.transform;
		this.transform.position = transform.parent.position;
	}

	public void DropBall()
	{
		playerInPossession.hasBall = false;
		playerInPossession = null;
		this.transform.position = transform.parent.position + transform.parent.transform.right;
		this.transform.parent = null;
		StartCoroutine(ShowBall (true));
	}

	public void PassBall(Player player)
	{
		playerInPossession = player;
		playerInPossession.hasBall = true;
		this.transform.parent = player.transform;
	}



}
