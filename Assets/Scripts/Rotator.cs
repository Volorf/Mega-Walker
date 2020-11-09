using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private const float ANGLE = 10f;
    private void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up,  ANGLE * Time.deltaTime);
    }
}
