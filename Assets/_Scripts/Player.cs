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

	public UnityStandardAssets._2D.PlatformerCharacter2D characterController;
//	public NinjaController.NinjaController playerController;

	public Weapon weapon;

	void Awake () {
		player = ReInput.players.GetPlayer (playerID);
		weapon = GetComponentInChildren<Weapon> ();
		characterController = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D> ();
	}
	
	void Update () 
	{
		isJumping = player.GetButtonDown ("Jump");
		isAttacking = player.GetButtonDown ("Attack");
		playerMovement = player.GetAxisRaw ("Move Horizontal");

//		if (playerController != null)
//		{
//			playerController.ProcessInputFromPlayer (isJumping, playerMovement);
//		}

		if (isJumping)
		{
			MusicManager.instance.PlaySFX (MusicManager.instance.hitClip);
//			Debug.Log (this.name + " is Jumping!!!");
		}

		if (isAttacking) {
			Debug.Log (this.name + " is Attacking!!!");
			MusicManager.instance.PlaySFX (MusicManager.instance.hitClip);
			weapon.gameObject.SetActive (true);
		} 
//		else 
//		{
//			weapon.gameObject.SetActive (false);
//		}
		
	}
}
