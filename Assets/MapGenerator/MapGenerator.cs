using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour {
    public GameObject partOfMapLeft;
    private Transform posLastPartOfMapLeft;
    public GameObject partOfMapRight;
    private Transform posLastPartOfMapRight;

    public GameObject rotateAllowPlatform;
    public GameObject regularPlatform;
    public GameObject bouncingPlatform;
    public GameObject notMovablePlatform;
    public GameObject enemyPlatform;

    public Transform playerPos;
    
    private void Start() {
        GenerateMap();
        StartCoroutine(needGenerate());
    }

    public void GenerateMap() {
        for (int i = 0; i < 10; i++) {
            GameObject curPartOfMapLeft = Instantiate(partOfMapLeft);
            if (posLastPartOfMapLeft != null) {
                curPartOfMapLeft.transform.position = new Vector3(Mathf.Clamp(posLastPartOfMapLeft.position.x - Random.Range(-3f, 3f), -25f, -8), posLastPartOfMapLeft.position.y, 0);
            }

            PartOfMap partOfMapLeftScript = curPartOfMapLeft.GetComponent<PartOfMap>();
            posLastPartOfMapLeft = partOfMapLeftScript.end;
            foreach (var part in partOfMapLeftScript.parts) {
                if (Random.Range(0, 2) == 0) {
                    part.AddComponent<DestroyItself>();
                }
            }
            GameObject curPartOfMapRight = Instantiate(partOfMapRight);
            if (posLastPartOfMapRight != null) {
                curPartOfMapRight.transform.position = new Vector3(Mathf.Clamp(posLastPartOfMapRight.position.x - Random.Range(-3f, 3f), 8f, 25), posLastPartOfMapRight.position.y, 0);
            }
            PartOfMap partOfMapRightScript = curPartOfMapRight.GetComponent<PartOfMap>();
            posLastPartOfMapRight = partOfMapRightScript.end;
            foreach (var part in partOfMapRightScript.parts) {
                if (Random.Range(0, 2) == 0) {
                    part.AddComponent<DestroyItself>();
                }
            }
            
            int randomNum = Random.Range(0, 100);
            GameObject nextPlatform = null;
            if (randomNum <= 60) {
                nextPlatform = rotateAllowPlatform;
            } else if (randomNum <= 80) {
                nextPlatform = bouncingPlatform;
            } else if (randomNum <= 95) {
                nextPlatform = enemyPlatform;
            } else if (randomNum <= 100) {
                nextPlatform = notMovablePlatform;
            }
            if (nextPlatform != null && posLastPartOfMapLeft != null) {
                GameObject curPlatform = Instantiate(nextPlatform);
                curPlatform.transform.position = new Vector2( Random.Range(-25f, 25f), posLastPartOfMapLeft.position.y - Random.Range(-3f, 3f));
                curPlatform.transform.Rotate(0, 0, Random.Range(-90f, 90f));
                curPlatform.transform.localScale = new Vector2(Random.Range(0.8f, 8f), Random.Range(0.8f, 8f));
                if (Random.Range(0, 2) == 0) {
                    curPlatform.AddComponent<DestroyItself>();
                }
                // if (Random.Range(0, 2) == 0) {
                //     curPlatform.AddComponent<RotationItself>();
                // }
            }
        }
    }

    IEnumerator needGenerate() {
        yield return new WaitForSeconds(0.1f);
        RaycastHit2D[] raycastAll = Physics2D.RaycastAll(new Vector2(playerPos.position.x - 30, playerPos.position.y - 30), Vector3.right, 50);
        if (raycastAll.Length == 0) {
            GenerateMap();
        }

        StartCoroutine(needGenerate());
    }
}
