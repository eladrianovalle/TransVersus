using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRender : MonoBehaviour {

	public SpriteRenderer sRenderer;
	public Player player;

	void Awake () 
	{
		sRenderer = GetComponent<SpriteRenderer> ();
		player = GetComponentInParent<Player> ();
	}
	
	void Update () 
	{
		if (player.hasBall)
		{
			sRenderer.sprite = player.holdingBallSprite;
		}
		else if (player.isStunned)
		{
			sRenderer.sprite = player.stunnedSprite;
		}
		else
		{
			sRenderer.sprite = player.regularSprite;
		}
	}
}
