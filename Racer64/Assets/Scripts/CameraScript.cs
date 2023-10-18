using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public float elapsedTime;

    public Vector3 offset;
    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / 15;

        transform.LookAt(player);

        //transform.position = Vector3.Lerp(transform.position, player.position + offset, 0.1f);

        transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref velocity, 0.3f);

        //transform.RotateAround(player.position, transform.right, -Input.GetAxis("Mouse Y") * 5);
        //transform.RotateAround(player.position, transform.up, Input.GetAxis("Mouse X") * 5);
    }
}
