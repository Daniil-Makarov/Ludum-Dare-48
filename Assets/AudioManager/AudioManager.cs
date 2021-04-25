using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    
    public AudioSource pressButton;
    public AudioSource jump;
    public AudioSource dead;
    public AudioSource win;

    private void Start() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void PlayPressButton() {
        pressButton.Play();
    }
    
    public void PlayJump() {
        jump.Play();
    }
    
    public void PlayDead() {
        dead.Play();
    }
    
    public void PlayWin() {
        win.Play();
    }
}
