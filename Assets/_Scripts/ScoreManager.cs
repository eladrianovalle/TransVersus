using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	private Player playerWithBall, playerOnLeftDoor, playerOnRightDoor; 
	public ScoreDoor leftScoreDoor, rightScoreDoor;
	private bool playerIsOnLeftDoor, playerIsOnRightDoor;
	public Scoring scoringData;
	public LevelManager levelManager;
//	public CountdownTimer countDownTimer;
	public GameObject goalPanel;
	public BallSpawner ballSpawner;
	public PlayerSpawnLocation playerSpawner;

	public AudioSource goalScoreSoundFX, goalScoreVoice;


	void Update() {
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
//		countDownTimer.SetTimer(4f);
		goalPanel.SetActive(true);
		playerWithBall.GetStunned();
		StartCoroutine (ResetGame());
		playerIsOnLeftDoor = false;
		playerIsOnRightDoor = false;
	}

	void BlueTeamScores() {
		scoringData.blueScoreCount +=1;
//		countDownTimer.SetTimer(4f);
		goalPanel.SetActive(true);
		playerWithBall.GetStunned();
		StartCoroutine (ResetGame());
		playerIsOnLeftDoor = false;
		playerIsOnRightDoor = false;;
	}

	private IEnumerator ResetGame () {
		yield return new WaitForSeconds (4f);
		playerSpawner.SetLeftPlayerLocation();
		playerSpawner.SetRightPlayerLocation();
		ballSpawner.SetBallLocation();
		goalPanel.SetActive(false);
	}
}
