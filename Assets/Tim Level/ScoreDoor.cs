using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDoor : MonoBehaviour {

	public Sprite buttonPressed, doorOpen, buttonIdle;
	public bool playerOnButton, playerIsRed, playerIsBlue, playerOnOtherScoreDoor, onSameTeam, playerCanScore;
	public AudioSource doorPressedSound, doorOpenSound;
	public Player playerScript;
	public ScoreDoor myLinkedScoreDoor;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		playerOnButton = false;
		playerIsRed = false;
		playerIsBlue = false;
		playerOnOtherScoreDoor = false;
		onSameTeam = false;
		playerCanScore = false;
	}
//	(myvariabvle != null)

	void Update(){
		if (playerOnOtherScoreDoor == true) {
			Player playerOnOtherDoor = myLinkedScoreDoor.GetComponent<Player> ();

			if (myLinkedScoreDoor.playerIsBlue == true && playerIsBlue == true) {
				print ("blue team");
				onSameTeam = true;
			} else if (myLinkedScoreDoor.playerIsRed == true && playerIsRed == true) {
				print ("red team");

			}
		}
		// if sameteam is true - check if player has ball, if they do change the sprite to "SpriteRenderer.sprite = doorOpen;"
		//  check if player on other door has the ball, and change the sprite on myLinkedScoreDoor
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player")
		{
			playerScript = other.gameObject.GetComponent<Player> ();
		}

		playerOnButton = true;
		doorPressedSound.Play ();
		spriteRenderer.sprite = buttonPressed;
//		playerScript = other.gameObject.GetComponent<Player> ();

		if (playerScript != null)
		{
			if (playerScript.playerTeam == Player.Team.Blue) 
			{
				playerIsBlue = true;
			} 
			else if (playerScript.playerTeam == Player.Team.Red) 
			{
				playerIsRed = true;
			} 
			else 
			{
				Debug.LogError ("Player Team Enum not set");
			}
		}
			

		if (myLinkedScoreDoor.playerOnButton == true) 
		{
			print ("There is someone on the other door");
			playerOnOtherScoreDoor = true;

		} 
		else 
		{
			playerOnOtherScoreDoor = false;
		}


	}

	void OnTriggerExit2D(Collider2D other) {
		spriteRenderer.sprite = buttonIdle;
		playerOnButton = false;
		playerIsRed = false;
		playerIsBlue = false;
	}

}
