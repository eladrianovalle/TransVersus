using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Player : MonoBehaviour {

	public int playerID;
	public Rewired.Player player;

	public bool isJumping;
	public bool isAttacking;
	public float playerMovement;

	public bool hasBall;

	public enum PlayerID
	{
		PlayerOne, PlayerTwo, PlayerThree, PlayerFour
	}

	public enum Team
	{
		Red, Blue
	}

	public PlayerID thisPlayer;
	public Team playerTeam;
	public NinjaController.NinjaController playerController;

	void Awake () {
		player = ReInput.players.GetPlayer (playerID);
	}
	
	void Update () 
	{
		isJumping = player.GetButton ("Jump");
		isAttacking = player.GetButton ("Attack");
		playerMovement = player.GetAxisRaw ("Move Horizontal");

		playerController.ProcessInputFromPlayer (isJumping, playerMovement);

		if (isAttacking)
		{
			Debug.Log (this.name + " is Attacking!!!");
		}
		
	}
}
