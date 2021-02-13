using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public bool isFlat = true;
    private Rigidbody rigid;
    public int speed=10;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        Vector3 tilt = -Input.acceleration;

        if (isFlat)
            tilt = Quaternion.Euler(90, 0, 180) * tilt;

        rigid.velocity = tilt * speed;
    }
}
