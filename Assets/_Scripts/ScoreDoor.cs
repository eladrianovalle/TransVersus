using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDoor : MonoBehaviour {

	public Sprite buttonPressed, doorOpen, buttonIdle;
	public AudioSource doorPressedSound, doorOpenSound;
	public Player playerScript;
	public ScoreManager scoreManager;

	private SpriteRenderer spriteRenderer;


	void Awake() {
		if (this.transform.position.x < 0) {
			int leftNumber = Random.Range(0,100);
			print ("Left number = " + leftNumber);
			if (leftNumber < 50) {
				this.transform.position = new Vector2 (-31.31f,2.37f);

			} else {
				this.transform.position = new Vector2 (-31.31f,32.53f);
			}
		} else {
			int rightNumber = Random.Range(0,100);
			print ("Right number = " + rightNumber);
			if (rightNumber < 50) {
				this.transform.position = new Vector2 (31.31f,2.37f);
			} else {
				this.transform.position = new Vector2 (31.31f,32.81f);
			}
		}

	}

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}


	void OnTriggerEnter2D(Collider2D other) {
		doorPressedSound.Play ();
		spriteRenderer.sprite = buttonPressed;
		playerScript = other.gameObject.GetComponent<Player> ();

		if (this.transform.position.x < 0) {
			scoreManager.SetPlayerOnLeftScoreDoor(playerScript);
		} else {
			scoreManager.SetPlayerOnRightScoreDoor(playerScript);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		spriteRenderer.sprite = buttonIdle;
		if (this.transform.position.x < 0) {
			scoreManager.SetPlayerOnLeftScoreDoor(null);
		} else {
			scoreManager.SetPlayerOnRightScoreDoor(null);
		}
	}

	public void OpenScoreDoor() {
		spriteRenderer.sprite = doorOpen;
		print ("this sprite is not changing.");
	}

}
