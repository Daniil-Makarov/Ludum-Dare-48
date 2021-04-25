using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public ParticleSystem deadParticleSystem;
	private Camera mainCam;

	private Platform currentPlatformHold;

	private bool jumpAnim = false;
	private bool canChangeJumpAnim = true;
	private float step = 0.4f;
	private Vector3 jumpAnimStartScale;

	private Vector3 jumpAnimEndScale;

	//возвращает к прежней форме после анимации
	private bool goBack = false;
	private void Start() {
		mainCam = Camera.main;

		jumpAnimStartScale = new Vector3(0.25f, 0.25f, 1);
		jumpAnimEndScale = new Vector3(0.25f, 0.05f, 1);
	}

	private void Update() {
		// анимация прыжка
		if (jumpAnim) {
			if (!goBack)
				transform.localScale = Vector3.Lerp(transform.localScale, jumpAnimEndScale, step);
			else
				transform.localScale = Vector3.Lerp(transform.localScale, jumpAnimStartScale, step);

			if (Math.Abs(transform.localScale.y - jumpAnimEndScale.y) < 0.000001f) goBack = true;
			if (Math.Abs(transform.localScale.y - jumpAnimStartScale.y) < 0.000001f) {
				Invoke("setCanChangeJumpAnim", 0.6f);
				goBack = false;
				jumpAnim = false;
			}
		}

		if (Input.GetMouseButtonDown(0)) {
			Vector2 mousePoint = mainCam.ScreenToWorldPoint(Input.mousePosition);

			Collider2D[] colliderPlatforms = Physics2D.OverlapCircleAll(mousePoint, 1.5f);

			Platform platformHold = null;
			foreach (var colliderPlatform in colliderPlatforms) {
				if (colliderPlatform != null && colliderPlatform.CompareTag("NormalPlatform")) {
					colliderPlatform.TryGetComponent(out platformHold);
					break;
				}
			}

			if (platformHold != null) {
				currentPlatformHold = platformHold;
				platformHold.isPressing = true;
			}
		}
		else if (Input.GetMouseButtonUp(0)) {
			if (currentPlatformHold != null) {
				currentPlatformHold.isPressing = false;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		GameObject collision = other.gameObject;
		if (collision.CompareTag("NormalPlatform")) {
			if (canChangeJumpAnim) {
				canChangeJumpAnim = false;
				AudioManager.instance.PlayJump();
				jumpAnim = true;
			}
		}
		if (collision.CompareTag("Enemy")) {
			AudioManager.instance.PlayDead();
			deadParticleSystem.Play();
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.GetComponent<Rigidbody2D>().simulated = false;
			Invoke("GameOver", 0.5f);
		}
	}

	private void GameOver() {
		if (PlayerPrefs.GetInt("Score", 0) < Score.score) {
			PlayerPrefs.SetInt("Score", Score.score);
		}

		Score.score = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void setCanChangeJumpAnim() {
		canChangeJumpAnim = true;
	}
}