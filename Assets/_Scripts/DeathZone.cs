using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	public Vector3 SpawnPoint;
	public Player player;

	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.CompareTag("Sphere"))
		{
				col.transform.position = SpawnPoint;
		}
	}
}