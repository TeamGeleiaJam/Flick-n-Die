using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour
{
    public Vector3 point1;
    public Vector3 point2;
    public float speed;

    bool dir;

    float pos;

    private void Start()
    {
        transform.position = point1;
    }

    private void FixedUpdate()
    {
        pos += dir?speed/10:-speed/10;
        if (pos > 1 || pos < 0)
        {
            pos = (int)pos;
            dir = !dir;
        }
        transform.position = Vector3.Lerp(point1, point2, pos);
    }
}
