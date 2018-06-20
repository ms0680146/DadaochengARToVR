using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour {

    public Transform PlayerCamera;
    public Transform leftHand;
    public Transform rightHand;
    public Vector3 Threhold;

    void Update () {
         Vector3 leftDir = leftHand.transform.position - PlayerCamera.position;
         Vector3 rightDir = rightHand.transform.position - PlayerCamera.position;
         Vector3 dir = leftDir + rightDir;
        if(dir.magnitude > Threhold.magnitude)
        {
            transform.position += (dir * 0.3f);
        }

    }
}
