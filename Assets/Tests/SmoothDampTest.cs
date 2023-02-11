using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDampTest : MonoBehaviour
{
    public float maxSpeed;
    public float smoothTime;


    float input;
    float speed;
    float currentSpeed;
    float targetSpeed;



    private void FixedUpdate()
    {
        targetSpeed = input * maxSpeed;
        speed = Mathf.SmoothDamp(speed, targetSpeed, ref currentSpeed, smoothTime);
    }

    private void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
    }
}
