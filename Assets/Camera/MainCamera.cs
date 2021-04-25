using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour {
	private PostProcessVolume _postProcessVolume;
	private ChromaticAberration _chromaticAberration;
	private Bloom _bloom;

	float speed = 6f;
	private Transform target;

	private void Start() {
		if (SceneManager.GetActiveScene().buildIndex >= 2) {
			target = GameObject.FindWithTag("Player").transform;
			transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
		}

		_postProcessVolume = GetComponent<PostProcessVolume>();
		_postProcessVolume.profile.TryGetSettings(out _chromaticAberration);
		_postProcessVolume.profile.TryGetSettings(out _bloom);
		if (PlayerPrefs.HasKey("PostProcessing")) {
			if (PlayerPrefs.GetInt("PostProcessing") == 1) {
				GraphicsGood();
			}
			else {
				GraphicsBad();
			}
		}
	}

	void Update() {
		if (SceneManager.GetActiveScene().buildIndex >= 2) {
			Vector3 position = target.position;
			position.z = transform.position.z;
			//position.x = transform.position.x;
			transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
		}
	}

	public bool ChangeGraphics() {
		if (_chromaticAberration.intensity.value != 0) {
			GraphicsBad();
			PlayerPrefs.SetInt("PostProcessing", 0);
			return false;
		}
		else {
			GraphicsGood();
			PlayerPrefs.SetInt("PostProcessing", 1);
			return true;
		}
	}

	private void GraphicsGood() {
		_chromaticAberration.intensity.value = 0.17f;
		_bloom.intensity.value = 10;
	}

	private void GraphicsBad() {
		_chromaticAberration.intensity.value = 0;
		_bloom.intensity.value = 0;
	}
}