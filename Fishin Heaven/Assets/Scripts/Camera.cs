using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
	public float x;
	public float y;
	public float z;
	public GameObject player;
	private Vector3 playerPos;

	void Update () {
		playerPos = player.transform.position;
		gameObject.transform.position = new Vector3 (playerPos.x + x, playerPos.y + y, playerPos.z + z);
	}
}
