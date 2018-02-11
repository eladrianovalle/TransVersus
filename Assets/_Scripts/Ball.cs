using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private SpriteRenderer sRenderer;
	private Collider2D coll;
//	private Rigidbody2D rBody;
	private float dropBallTimer;

	public bool canScore = false;
	public bool isVisibe = false;
	public ScoreManager scoreManager;
	public BallSpawner ballSpawner;
	public Player playerInPossession, playerWhoDroppedBall, player1, player2, player3, player4;

	void Awake () 
	{
		sRenderer = GetComponentInChildren<SpriteRenderer> ();
		coll = GetComponent<Collider2D> ();
//		rBody = GetComponent<Rigidbody2D> ();
	}

	void Start()
	{
		ShowBall (true);
	}
	
	void Update () {
		if (playerInPossession != null) {
			if (playerInPossession.isStunned) {
				DropBall ();
			}
		}

		if (dropBallTimer > 0) {
			dropBallTimer -= Time.deltaTime;
		} else {
			playerWhoDroppedBall = null;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Player player = other.gameObject.GetComponent<Player> ();
			if (player != playerWhoDroppedBall) {
				PickupBall (player);
			}

		}
	}

	public IEnumerator ShowBall(bool showBall)
	{
		isVisibe = showBall;
		sRenderer.enabled = isVisibe;
		player1.hasBall=false;
		player2.hasBall=false;
		player3.hasBall=false;
		player4.hasBall=false;
		var timeToWait = 0.0f;
		if (!isVisibe) {timeToWait = 1f;}
		yield return new WaitForSecondsRealtime (timeToWait);
		coll.enabled = isVisibe;
	}

//	public void ShowBall(bool showBall){
//		isVisibe = showBall;
//		sRenderer.enabled = isVisibe;
//		coll.enabled = isVisibe;
//	}

	public void PickupBall(Player player)
	{
		StartCoroutine(ShowBall (false));

		playerInPossession = player;
		playerInPossession.hasBall = true;
		scoreManager.SetPlayerWithBall(player);
		this.transform.parent = player.transform;
		this.transform.position = transform.parent.position;
	}

	public void DropBall()
	{
		playerInPossession.hasBall = false;
		playerInPossession = playerWhoDroppedBall;
		dropBallTimer = 1.25f;

		playerInPossession = null;
		scoreManager.SetPlayerWithBall(null);
		this.transform.position = transform.parent.position + transform.parent.transform.right;
		this.transform.parent = null;
		StartCoroutine(ShowBall (true));
//		ShowBall(true);
	}

	public void PassBall(Player player)
	{
		playerInPossession = player;
		playerInPossession.hasBall = true;
		this.transform.parent = player.transform;
	}


}
