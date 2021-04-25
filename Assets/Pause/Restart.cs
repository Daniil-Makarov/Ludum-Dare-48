using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartLevel() {
        AudioManager.instance.PlayPressButton();
        if (PlayerPrefs.GetInt("Score", 0) < Score.score) {
            PlayerPrefs.SetInt("Score", Score.score);
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
