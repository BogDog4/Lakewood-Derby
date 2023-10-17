using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{

    public Transform[] navnodes;
    public int i = 0;
    public float elapsedTime;
    public Rigidbody ghostRB;

    // Start is called before the first frame update
    void Start()
    {
        //ghostRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(navnodes[i].position.x, transform.position.y, navnodes[i].position.z), Vector3.left);

        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / 15;

        transform.position = Vector3.Lerp(transform.position, navnodes[i].position, percentageComplete);

        //ghostRB.AddForce(transform.forward * 25 * 25 * Time.deltaTime, ForceMode.Acceleration);
        

        if (transform.position == navnodes[i].position)
        {
            i++;
        }
    }
}
