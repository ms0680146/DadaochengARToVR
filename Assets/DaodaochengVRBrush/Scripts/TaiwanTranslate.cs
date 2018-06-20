using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaiwanTranslate : MonoBehaviour {


    void Update()
    {
        StartCoroutine(TaiwanMove());
        
        
    }

    IEnumerator TaiwanMove()
    {
        yield return new WaitForSeconds(10);
        if(transform.position.z < 2.02)
        {
            transform.Translate(Vector3.forward * 0.005f*Time.deltaTime);
        }else if(transform.position.z < 5)
        {
            transform.Translate(Vector3.forward * 0.1f * Time.deltaTime);
        }
       
    }
}
