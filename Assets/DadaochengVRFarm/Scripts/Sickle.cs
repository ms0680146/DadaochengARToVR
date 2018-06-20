using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : MonoBehaviour {


    public AudioSource RiceAudio;

    //兩個Box Collider互相引起(勾選is Trigger和加入Rigidbody)!
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "rice")
        {
            RiceAudio.Play();
            Destroy(col.gameObject);

        }
    }

}
