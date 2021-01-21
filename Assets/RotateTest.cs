using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    public int speed = 5;

    void FixedUpdate()
    {
        transform.Rotate(speed, 0, 0);
    }
}
