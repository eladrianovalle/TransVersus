using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	private Player playerWithBall, playerOnLeftDoor, playerOnRightDoor; 
	public ScoreDoor leftScoreDoor, rightScoreDoor;
	private bool playerIsOnLeftDoor, playerIsOnRightDoor;
	public Scoring scoringData;
	public LevelManager levelManager;
	public GameObject goalPanel;
	public BallSpawner ballSpawner;
	public PlayerSpawnLocation playerSpawner;
	public Ball ball;
	public AudioSource goalScoreSoundFX, goalScoreVoice;
	public SpriteRenderer backgroundSprite;
	public Color standard, red, blue;

	void Awake () {
		backgroundSprite.color = standard;
	}

	void Update() {
//		if (playerWithBall){
//			if (playerWithBall.playerTeam==Player.Team.Red) {
//				backgroundSprite.color = Color.Lerp(standard,blue,Time.deltaTime * 2f);
//				print ("fuck");
//			} else if (playerWithBall.playerTeam==Player.Team.Blue) {
//				backgroundSprite.color = Color.Lerp(standard,red,Time.deltaTime * 2f);
//				print ("red");
//			} else {
//				backgroundSprite.color = standard;
//			}
//		}


		if (playerIsOnLeftDoor==true && playerIsOnRightDoor==true) {
			if (playerOnLeftDoor.playerTeam==playerOnRightDoor.playerTeam) {
				if (playerWithBall.playerTeam==playerOnLeftDoor.playerTeam) {
					if (playerWithBall.transform.position.x < 0) {
						leftScoreDoor.OpenScoreDoor();
					} else {
						rightScoreDoor.OpenScoreDoor();
					}
					if (playerWithBall.playerID==0 || playerWithBall.playerID==2) {
						goalScoreSoundFX.Play();
						goalScoreVoice.Play();
						RedTeamScores();
					} else {
						goalScoreSoundFX.Play();
						goalScoreVoice.Play();
						BlueTeamScores();
					}
				} else {
					return;
				}
			} else {
				return;
			}
		} else {
			return;
		}
	}

	public void SetPlayerOnLeftScoreDoor(Player player) {
		if (player) {
			playerOnLeftDoor = player;
			playerIsOnLeftDoor = true;
		} else {
			playerOnLeftDoor = null;
			playerIsOnLeftDoor = false;
		}

	}

	public void SetPlayerOnRightScoreDoor(Player player){
		if (player) {
			playerOnRightDoor = player;
			playerIsOnRightDoor = true;
		} else {
			playerOnRightDoor = null;
			playerIsOnRightDoor = false;
		}

	}

	public void SetPlayerWithBall(Player player) {
		playerWithBall = player;
		if (playerWithBall) {
			print (playerWithBall + " has the ball");
		}
	}

	void RedTeamScores(){
		scoringData.redScoreCount +=1;
		goalPanel.SetActive(true);
		ball.DropBall();

		StartCoroutine (ResetGame());
		playerIsOnLeftDoor = false;
		playerIsOnRightDoor = false;
	}

	void BlueTeamScores() {
		scoringData.blueScoreCount +=1;
		goalPanel.SetActive(true);
		ball.DropBall();

		StartCoroutine (ResetGame());
		playerIsOnLeftDoor = false;
		playerIsOnRightDoor = false;;
	}

	private IEnumerator ResetGame () {
		yield return new WaitForSeconds (4f);
		playerSpawner.SetLeftPlayerLocation();
		playerSpawner.SetRightPlayerLocation();
		ball.gameObject.SetActive(true);
		ballSpawner.SetBallLocation();
		goalPanel.SetActive(false);
	}
}
