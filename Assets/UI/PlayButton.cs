using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void StartGame() {
        AudioManager.instance.PlayPressButton();
        SceneManager.LoadScene(2);
    }
}
