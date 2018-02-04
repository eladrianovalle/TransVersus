using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour {

	public GameObject playerInPortal;
	private Portals portals;
	public float spacing = 2f;

	public enum Color {Red,Green,Blue};
	public Color thisColor;
	public AudioSource portalSound;

	// Use this for initialization
	void Start () {
		portals = GetComponentInParent<Portals>();
		portalSound = GetComponent<AudioSource> ();
	}
	


	void OnTriggerEnter2D(Collider2D other) {
		playerInPortal = other.gameObject;
		portalSound.Play ();
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ball") {
			if (this.transform.position.x > 0) {
				if (thisColor == Color.Red) {
					playerInPortal.transform.position = new Vector2 (portals.leftPortalRed.transform.position.x - spacing, portals.leftPortalRed.transform.position.y);
					playerInPortal = null;
				} else if (thisColor == Color.Green) {
					playerInPortal.transform.position = new Vector2 (portals.leftPortalGreen.transform.position.x - spacing, portals.leftPortalGreen.transform.position.y);
					playerInPortal = null;
				} else if (thisColor == Color.Blue) {
					playerInPortal.transform.position = new Vector2 (portals.leftPortalBlue.transform.position.x - spacing, portals.leftPortalBlue.transform.position.y);
					playerInPortal = null;
				}
			} else {
				if (thisColor == Color.Red) {
					playerInPortal.transform.position = new Vector2 (portals.rightPortalRed.transform.position.x + spacing, portals.rightPortalRed.transform.position.y);
					playerInPortal = null;
				} else if (thisColor == Color.Green) {
					playerInPortal.transform.position = new Vector2 (portals.rightPortalGreen.transform.position.x + spacing, portals.rightPortalGreen.transform.position.y);
					playerInPortal = null;
				} else if (thisColor == Color.Blue) {
					playerInPortal.transform.position = new Vector2 (portals.rightPortalBlue.transform.position.x + spacing, portals.rightPortalBlue.transform.position.y);
					playerInPortal = null;
				}
			}
		}


	
	}


}
