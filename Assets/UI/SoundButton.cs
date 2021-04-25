using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SoundButton : MonoBehaviour {
    private TextMeshProUGUI text;
    public AudioMixerGroup mixer;
    private void Start() {
        text = GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.HasKey("MasterVolume")) {
            if (PlayerPrefs.GetInt("MasterVolume") == 1) {
                mixer.audioMixer.SetFloat("MasterVolume", 0);
                text.text = "Sound\non";
            }
            else {
                mixer.audioMixer.SetFloat("MasterVolume", -80);
                text.text = "Sound\noff";
            }
        }
    }

    public void ChangeVolume() {
        AudioManager.instance.PlayPressButton();
        float mixerMasterVolume;
        mixer.audioMixer.GetFloat("MasterVolume", out mixerMasterVolume);
        if (mixerMasterVolume == 0) {
            mixer.audioMixer.SetFloat("MasterVolume", -80);
            PlayerPrefs.SetInt("MasterVolume", 0);
            text.text = "Sound\noff";
        }
        else {
            mixer.audioMixer.SetFloat("MasterVolume", 0);
            PlayerPrefs.SetInt("MasterVolume", 1);
            text.text = "Sound\non";
        }
    }
}