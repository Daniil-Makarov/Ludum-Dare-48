using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GraphicsButton : MonoBehaviour {
    private TextMeshProUGUI text;
    private MainCamera mainCam;
    private void Start() {
        text = GetComponent<TextMeshProUGUI>();
        mainCam = Camera.main.GetComponent<MainCamera>();
        if (PlayerPrefs.HasKey("PostProcessing")) {
            if (PlayerPrefs.GetInt("PostProcessing") == 1) {
                text.text = "Graphics\ngood";
            }
            else {
                text.text = "Graphics\nbad";
            }
        }
    }

    public void ChangeGraphics() {
        AudioManager.instance.PlayPressButton();
        bool isGoodGraphics = mainCam.ChangeGraphics();
        text.text = isGoodGraphics ? "Graphics\ngood" : "Graphics\nbad";
    }
}
