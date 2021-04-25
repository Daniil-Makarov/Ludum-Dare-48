using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {
	private TextMeshProUGUI text;
	public static int score;

	private void Start() {
		score = 0;
		text = GetComponent<TextMeshProUGUI>();
	}

	private void LateUpdate() {
		text.text = score.ToString();
	}
}