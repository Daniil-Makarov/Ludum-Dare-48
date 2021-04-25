using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaEnemy : MonoBehaviour {
	private float speed = 1.74f;
	public GameObject player;
	public Transform end;

	void Update() {
		if (player.transform.position.y < end.position.y - 45)
			speed = 28f;
		else if (player.transform.position.y < end.position.y - 20)
			speed = 16f;
		else if (player.transform.position.y < end.position.y - 10)
			speed = 8f;
		else if (player.transform.position.y < end.position.y - 3)
			speed = 5f;

		transform.position = new Vector3(0, transform.position.y - speed * Time.deltaTime, 10);
	}
}