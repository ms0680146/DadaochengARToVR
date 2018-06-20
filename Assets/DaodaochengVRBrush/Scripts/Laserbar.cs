using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserbar : MonoBehaviour {

    LineRenderer LineRend;
    public Transform startPos;
    public Transform endPos;
     
	// Use this for initialization
	void Start () {
        LineRend = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //update line positions//
        LineRend.SetPosition(0, startPos.position);
        LineRend.SetPosition(1 , endPos.position);
    }
}
