using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform com;

    public WheelCollider frontRight;
    public WheelCollider frontLeft;
    public WheelCollider backRight;
    public WheelCollider backLeft;

    public Transform frontRightTransform;
    public Transform frontLeftTransform;
    public Transform backRightTransform;
    public Transform backLeftTransform;

    public float acceleration = 500;
    public float maxturn = 50;

    private float moveforward;
    private float usebreaks;
    private float turnangle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.centerOfMass = com.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        moveforward = acceleration * Input.GetAxis("Vertical");
        turnangle = maxturn * Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.S))
        {
            usebreaks = 10000;
        }else
        {
            usebreaks = 0f;
        }

        frontRight.motorTorque = moveforward;
        frontLeft.motorTorque = moveforward;

        frontRight.brakeTorque = usebreaks;
        frontLeft.brakeTorque = usebreaks;
        backLeft.brakeTorque = usebreaks;
        backRight.brakeTorque = usebreaks;
        
        frontLeft.steerAngle = turnangle;
        frontRight.steerAngle = turnangle;
    }
}
