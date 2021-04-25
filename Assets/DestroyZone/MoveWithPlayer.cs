using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : MonoBehaviour {
    private Transform playerPos;
    void Start() {
        playerPos = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, playerPos.position.y);
    }
}
