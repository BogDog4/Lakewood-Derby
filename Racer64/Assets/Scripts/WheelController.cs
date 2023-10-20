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
    public float playerYrotation;

    public GhostCarSpawnerScript spawnerScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnerScript = GameObject.Find("LapTrigger").GetComponent<GhostCarSpawnerScript>();
        //rb.centerOfMass = com.position;
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = transform.position + new Vector3(0, 0.5f, 0);
            playerYrotation = transform.localRotation.eulerAngles.y;
            transform.eulerAngles = new Vector3 (0,playerYrotation,0);
        }
    }

    void FixedUpdate()
    {

        moveforward = acceleration * Input.GetAxis("Vertical");
        turnangle = maxturn * Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LapTrigger")
        {
            spawnerScript.SpawnCar();
        }
    }
}
