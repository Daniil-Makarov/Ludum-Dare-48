using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyPlatform : MonoBehaviour
{
    public Transform[] points;
    public float speed = 4f;
    public float waitTime = 3f;
    bool CanGo = true;
    int i = 1;
    
    void Start()
    {
        gameObject.transform.position = new Vector3(points[0].position.x, points[0].position.y, transform.position.z);
    }

    void Update()
    {
        if (CanGo)
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

        if (transform.position == points[i].position)
        {
            if (i < points.Length - 1)
            {
                i++;
            } else
            {
                i = 0;
            }
            // if (i == 2)
            // {
            //     speed += 12f;
            // } else
            // {
            //     speed = 4f;
            // }
            CanGo = false;
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(waitTime);
        CanGo = true;
    }
}
