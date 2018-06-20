using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleport_ARVR : MonoBehaviour {

    public GameObject TeleportMarker;
    public float RayLength = 50f;
    float time;
    float gazeduration = 3;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, RayLength))
        {
            if (hit.collider.tag == "ARToVRButton")
            {
                time += Time.deltaTime;
                if (!TeleportMarker.activeSelf)
                {
                    TeleportMarker.SetActive(true);
                }
                TeleportMarker.transform.position = hit.point;
                VRTransition();
            }
        }else{
            TeleportMarker.SetActive(false);
            time = 0f;
        }
    }

    void VRTransition()
    {
        if (TeleportMarker.activeSelf && time >= gazeduration)
        {
            SceneManager.LoadScene("DadaochengVRTransition");
        }
    }
}
