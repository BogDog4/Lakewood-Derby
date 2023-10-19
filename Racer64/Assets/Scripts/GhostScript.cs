using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{

    public Transform[] day1navnodes;
    public Transform[] night1navnodes;
    public Transform[] day2navnodes;
    public Transform[] night2navnodes;
    public Transform[] day3navnodes;
    public Transform[] night3navnodes;
    public Transform[] day4navnodes;
    public Transform[] night4navnodes;
    public Transform[] day5navnodes;
    public Transform[] night5navnodes;

    public int i = 0;
    public float elapsedTime;
    public Rigidbody ghostRB;
    public Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        ghostRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(day1navnodes[i].position.x, transform.position.y, day1navnodes[i].position.z));

        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / 15;

        //transform.position = Vector3.Lerp(transform.position, navnodes[i].position, percentageComplete);

        ghostRB.AddForce(transform.forward * 25 * 16 * Time.deltaTime, ForceMode.Acceleration);

        distance = day1navnodes[i].position - transform.position;
        

        if (elapsedTime > 7)
        {
            elapsedTime = 0;
            distance = new Vector3 (0,0,0);
            //i++;
        }

        if (i >= 9)
        {
            //i = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "node")
        {
            i++;
        }
    }
}
