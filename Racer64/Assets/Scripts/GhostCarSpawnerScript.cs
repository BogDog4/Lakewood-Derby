using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCarSpawnerScript : MonoBehaviour
{

    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;

    public bool ifnight = false;

    public float night = 0;

    public Material daySkybox;
    public Material nightSkybox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCar()
    {
        Debug.Log("Trigger was tripped!");

        if (!ifnight)
        {
            night += 1;
            ifnight = true;
        }else
        {
            ifnight = false;
        }

        switch (night)
        {
            case 5:
            Debug.Log("Spawn car for night 5");
            break;
            case 4:
            Debug.Log("Spawn car for night 4");
            break;
            case 3:
            Debug.Log("Spawn car for night 3");
            break;
            case 2:
            Debug.Log("Spawn car for night 2");
            break;
            case 1:
            Debug.Log("Spawn car for night 1");
            break;
        }
    }
}
