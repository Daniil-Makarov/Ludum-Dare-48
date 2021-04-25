using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour {
	public Rigidbody2D rb;
	public SpriteRenderer SpriteRenderer;
	public ParticleSystem ParticleSystem;
	public BoxCollider2D hitBox;
	
	public bool isPressing = false;
	private Camera mainCam;
	
	// платформа больше не будет нажиматся
	private bool isCompleted = false;

	void Start() {
		mainCam = Camera.main;
	}

	private void Update() {
		if (isPressing) {
			rb.isKinematic = true;
			hitBox.enabled = false;
			rb.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
		}
		else {
			rb.isKinematic = false;
			hitBox.enabled = true;
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (!isCompleted && other.gameObject.CompareTag("Player") && !rb.isKinematic) {
			ParticleSystem.Play();
			SpriteRenderer.color = Color.yellow;
			isCompleted = true;
			if (SceneManager.GetActiveScene().buildIndex >= 2)
				Score.score++;
		}
	}
}