using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureDissolveControl : MonoBehaviour {

    public Material dissolveMaterial;
    public float speed;

    private float maxThreshold = 1f;
    private float Threshold;

    void Update()
    {
        StartCoroutine(DissolveEffect());
    }

    IEnumerator DissolveEffect()
    {
        yield return new WaitForSeconds(5);
        if (Threshold < maxThreshold)
        {
            dissolveMaterial.SetFloat("_Threshold", Threshold);
            Threshold += Time.deltaTime * speed;
        }
        else
        {
            Threshold = 1;
        }
    }
}

