using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationItself : MonoBehaviour
{
    void Update()
    {
	    transform.Rotate(0, 0, Time.deltaTime);
    }
}
