using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	private Player playerWithBall;
	public Player player1, player2, player3, player4;
	public ScoreDoor leftScoreDoor, rightScoreDoor;
	public bool checkScoreCondition;
	public Scoring scoringData;
	public LevelManager levelManager;
	public GameObject goalPanel, gameOverPanel;
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

	}


	public void SetPlayerWithBall(Player player) {
		playerWithBall = player;
		if (playerWithBall) {
			print (playerWithBall + " has the ball");
		}
	}

	void RedTeamScores(){
		scoringData.redScoreCount +=1;
		if (scoringData.redScoreCount == LevelManager.goalAmount && LevelManager.timedGame==false) {
			gameOverPanel.SetActive(true);
			musicManager.FadeOutMusic();
			player1.DestroyGameObject();
			player2.DestroyGameObject();
			player3.DestroyGameObject();
			player4.DestroyGameObject();
		} else {
			goalPanel.SetActive(true);
			ball.DropBall();
			playerSpawner.PlayerIsDisabled();
			StartCoroutine (ResetGame());
		}
	}

	void BlueTeamScores() {
		scoringData.blueScoreCount +=1;
		if (scoringData.blueScoreCount == LevelManager.goalAmount && LevelManager.timedGame==false) {
			gameOverPanel.SetActive(true);
			musicManager.FadeOutMusic();
			player1.DestroyGameObject();
			player2.DestroyGameObject();
			player3.DestroyGameObject();
			player4.DestroyGameObject();
		} else {
			goalPanel.SetActive(true);
			ball.DropBall();
			playerSpawner.PlayerIsDisabled();
			StartCoroutine (ResetGame());
		}
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
