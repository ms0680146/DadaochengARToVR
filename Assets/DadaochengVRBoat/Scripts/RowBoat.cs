using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowBoat : MonoBehaviour {

    public GameObject Boat;
    public bool isInWater = false;


    void OnTriggerEnter(Collider col)
    {
        isInWater = true;
        Debug.Log("touch");
    }

    void OnTriggerExit(Collider col)
    {
        isInWater = false;
        Debug.Log("untouch");
    }

    void FixedUpdate()
    {
        if (isInWater)
        {
            Boat.transform.position += Vector3.left*0.5f* Time.deltaTime ;
        }  
    }

}
