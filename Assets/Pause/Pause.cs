using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    private bool onEnable = false;
    public GameObject panelPause;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!onEnable) {
                Time.timeScale = 0;
                panelPause.SetActive(true);
                onEnable = true;
            }
            else {
                Time.timeScale = 1;
                panelPause.SetActive(false);
                onEnable = false;
            }
        }
    }
}
