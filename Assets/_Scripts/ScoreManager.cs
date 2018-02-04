using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	private Player playerWithBall;
//playerOnLeftDoor, playerOnRightDoor; 
	public Player player1, player2, player3, player4;
	public ScoreDoor leftScoreDoor, rightScoreDoor;
//	private bool playerIsOnLeftDoor, playerIsOnRightDoor;
	public bool checkScoreCondition;
	public Scoring scoringData;
	public LevelManager levelManager;
	public GameObject goalPanel;
	public BallSpawner ballSpawner;
	public PlayerSpawnLocation playerSpawner;
	public Ball ball;
	public AudioSource goalScoreSoundFX, goalScoreVoice;
	public SpriteRenderer backgroundSprite;
	public Color currentColor,standard, red, blue;
	public MusicManager musicManager;

	void Awake () {
		backgroundSprite.color = standard;
		checkScoreCondition = false;
	}

	void Update() {
		if (playerWithBall) {
			currentColor = backgroundSprite.color;
			if (playerWithBall.playerTeam == Player.Team.Red) {
				backgroundSprite.color = Color.Lerp(currentColor,red,Mathf.PingPong(Time.time, 1));
				musicManager.PlayRedTeamTheme ();
			} else if (playerWithBall.playerTeam == Player.Team.Blue) {
				backgroundSprite.color = Color.Lerp(currentColor,blue,Mathf.PingPong(Time.time, 1));
				musicManager.PlayBlueTeamTheme ();
			}
		} else {
			currentColor = backgroundSprite.color;
			backgroundSprite.color = Color.Lerp(currentColor,standard,Mathf.PingPong(Time.time, 1));
			musicManager.PlayFilteredBGtrack ();
		}

		if (checkScoreCondition) {
			if (player1.onScoreDoor == true && player3.onScoreDoor==true) {
				if (player1.hasBall == true || player3.hasBall ==true) {
					if (playerWithBall.transform.position.x < 0) {
						leftScoreDoor.OpenScoreDoor();
					} else {
						rightScoreDoor.OpenScoreDoor();
					}
					RedTeamScores();
					goalScoreSoundFX.Play();
					goalScoreVoice.Play();
				}
			}
			if (player2.onScoreDoor == true && player4.onScoreDoor==true) {
				if (player2.hasBall == true || player4.hasBall ==true) {
					BlueTeamScores();
					goalScoreSoundFX.Play();
					goalScoreVoice.Play();
				}
			}
		}
//		if (playerIsOnLeftDoor==true && playerIsOnRightDoor==true) {
//			if (playerOnLeftDoor.playerTeam==playerOnRightDoor.playerTeam) {
//				if (playerWithBall.playerTeam==playerOnLeftDoor.playerTeam) {
//					if (playerWithBall.transform.position.x < 0) {
//						leftScoreDoor.OpenScoreDoor();
//					} else {
//						rightScoreDoor.OpenScoreDoor();
//					}
//					if (playerWithBall.playerID==0 || playerWithBall.playerID==2) {
//						goalScoreSoundFX.Play();
//						goalScoreVoice.Play();
//						RedTeamScores();
//					} else {
//						goalScoreSoundFX.Play();
//						goalScoreVoice.Play();
//						BlueTeamScores();
//					}
//				} else {
//					return;
//				}
//			} else {
//				return;
//			}
//		} else {
//			return;
//		}
	}

//	public void SetPlayerOnLeftScoreDoor(Player player) {
//		if (player) {
//			playerOnLeftDoor = player;
//			playerIsOnLeftDoor = true;
//		} else {
//			playerOnLeftDoor = null;
//			playerIsOnLeftDoor = false;
//		}
//
//	}
//
//	public void SetPlayerOnRightScoreDoor(Player player){
//		if (player) {
//			playerOnRightDoor = player;
//			playerIsOnRightDoor = true;
//		} else {
//			playerOnRightDoor = null;
//			playerIsOnRightDoor = false;
//		}
//
//	}

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
		playerSpawner.PlayerIsDisabled();
		StartCoroutine (ResetGame());
//		playerIsOnLeftDoor = false;
//		playerIsOnRightDoor = false;
	}

	void BlueTeamScores() {
		scoringData.blueScoreCount +=1;
		goalPanel.SetActive(true);
		ball.DropBall();
		playerSpawner.PlayerIsDisabled();
		StartCoroutine (ResetGame());
//		playerIsOnLeftDoor = false;
//		playerIsOnRightDoor = false;;
	}

	private IEnumerator ResetGame () {
		yield return new WaitForSeconds (4f);
		playerSpawner.SetLeftPlayerLocation();
		playerSpawner.SetRightPlayerLocation();
		playerSpawner.PlayerIsEnabled();
		ball.gameObject.SetActive(true);
		ballSpawner.SetBallLocation();
		goalPanel.SetActive(false);
	}
}
