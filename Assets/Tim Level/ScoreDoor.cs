using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDoor : MonoBehaviour {

	public Sprite buttonPressed, doorOpen, buttonIdle;
	public bool playerOnButton, playerIsRed, playerIsBlue;
	public AudioSource doorPressedSound, doorOpenSound;
	public Player playerScript;
	public GameObject myLinkedScoreDoor;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		playerOnButton = false;
		playerIsRed = false;
		playerIsBlue = false;
	}
	


	void OnTriggerEnter2D(Collider2D other) {
		playerOnButton = true;
		doorPressedSound.Play ();
		spriteRenderer.sprite = buttonPressed;
		playerScript = other.gameObject.GetComponent<Player> ();

		if (playerScript.playerTeam == Player.Team.Blue) {
			playerIsBlue = true;
		} else if (playerScript.playerTeam == Player.Team.Red) {
			playerIsRed = true;
		} else {
			Debug.LogError ("Player Team Enum not set");
		}

		// check to see if you of the person on the other Door has the ball.
		if (playerScript.hasBall == true || myLinkedScoreDoor.gameObject.GetComponent<Player> ().hasBall == true) {

			// check to see if there is someone of the other Door.
			if (myLinkedScoreDoor.gameObject.GetComponent<ScoreDoor> ().playerOnButton == true) {
				print ("There is someone on the other door");

				// check to see if the person on the other door is your teammate.
				if (myLinkedScoreDoor.gameObject.GetComponent<ScoreDoor>().playerIsBlue == true && playerIsBlue == true) {

					//this opens the door for the person with the ball
					if (myLinkedScoreDoor.gameObject.GetComponent<Player> ().hasBall == true) {
						SpriteRenderer theirSpriteRenderer = myLinkedScoreDoor.gameObject.GetComponent<SpriteRenderer> (); 
						theirSpriteRenderer.sprite = doorOpen;
						print ("Blue team scores!");
						// dump ball, increase score for Blue team
					} else {
						spriteRenderer.sprite = doorOpen;
						print ("Blue team scores!");
						// dump ball, increase score for Blue team
					}

				} else if (myLinkedScoreDoor.gameObject.GetComponent<ScoreDoor>().playerIsRed == true && playerIsRed == true) {
					if (myLinkedScoreDoor.gameObject.GetComponent<Player> ().hasBall == true) {
						SpriteRenderer theirSpriteRenderer = myLinkedScoreDoor.gameObject.GetComponent<SpriteRenderer> (); 
						theirSpriteRenderer.sprite = doorOpen;
						print ("Red team scores!");
						// dump ball, increase score for Red team
					} else {
						spriteRenderer.sprite = doorOpen;
						print ("Red team scores!");
						// dump ball, increase score for Red team
					}
				}
			}
		}



	}

	void OnTriggerExit2D(Collider2D other) {
		spriteRenderer.sprite = buttonIdle;
		playerOnButton = false;
		playerIsRed = false;
		playerIsBlue = false;
	}

}
