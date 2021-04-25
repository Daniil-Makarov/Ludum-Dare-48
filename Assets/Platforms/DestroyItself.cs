using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItself : MonoBehaviour {
	private bool isDestroyed = false;
	private float destoyStep = 0;
	private void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.CompareTag("Player")) {
			Invoke("Destroy", 0.2f);
		}
	}

	private void Destroy() {
		isDestroyed = true;
	}

	private void Update() {
		if (isDestroyed) {
			destoyStep += Time.deltaTime / 1.2f;
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, destoyStep);
		}

		if (transform.localScale.Equals(Vector3.zero)) {
			Destroy(gameObject);
		}
	}
}
