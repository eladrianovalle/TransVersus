using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Player : MonoBehaviour {

	public int playerID;
	public Rewired.Player player;

	bool playerJumping;
	float playerMovement;

	public enum PlayerID
	{
		PlayerOne, PlayerTwo, PlayerThree, PlayerFour
	}

	public PlayerID thisPlayer;
	public NinjaController.NinjaController playerController;

	void Awake () {
		player = ReInput.players.GetPlayer (playerID);
	}
	
	void Update () 
	{
		playerJumping = player.GetButton ("Jump");
		playerMovement = player.GetAxisRaw ("Move Horizontal");

		playerController.ProcessInputFromPlayer (playerJumping, playerMovement);

		if (player.GetButtonDown("Attack"))
		{
			Debug.Log (this.name + " is Attacking!!!");
		}
		
	}
}
