using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Record : MonoBehaviour
{
    void Start() {
        GetComponent<TextMeshProUGUI>().text = "Record - " + PlayerPrefs.GetInt("Score", 0);
    }
}
