using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine;

public class FOVLimiter : MonoBehaviour {

    private Vector3 oldPos;
    public float MaxSpeed = 6f;
    public float MaxFOV = .7f;
    private VignetteAndChromaticAberration fovlimiter;
	// Use this for initialization
	void Start () {
        oldPos = transform.position;
        fovlimiter = GetComponent<VignetteAndChromaticAberration>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 velocity = (transform.position - oldPos) / Time.deltaTime;
        oldPos = transform.position;

        float expectedLimit = MaxFOV;
        if (velocity.magnitude < MaxSpeed)
            expectedLimit = (velocity.magnitude / MaxSpeed) * MaxFOV;
        fovlimiter.intensity = Mathf.Lerp(fovlimiter.intensity, expectedLimit, .01f);
	}
}
