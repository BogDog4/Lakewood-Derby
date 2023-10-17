using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingScript : MonoBehaviour
{
    public Rigidbody carRB;
    public float speed = 25;
    public float speedMultiplier = 10;
    public float turnSpeed = 35;

    Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        //grab rigidbody of car
        carRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //get input axis
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //set rotation to horizontal axis and reverse if you are going in reverse
        rotation = new Vector3(0, horizontal, 0);

        //turn into a quaternion
        Quaternion deltaRotation = Quaternion.Euler(rotation * turnSpeed * Time.deltaTime);

        //turn based on how fast you are moving
        turnSpeed = vertical * 9 * carRB.velocity.magnitude;

        //push the car in these directions
        carRB.AddForce(transform.forward * vertical * speed * speedMultiplier * Time.deltaTime, ForceMode.Acceleration);
        if (vertical > 0 || vertical < 0)
        {
            carRB.MoveRotation(carRB.rotation * deltaRotation);
        }
    }
}
