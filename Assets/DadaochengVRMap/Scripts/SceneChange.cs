using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class SceneChange : MonoBehaviour {

    public GameObject TeleportMarker;
    public List<GameObject> SceneIcons;
    public float RayLength = 50f;
    float time;
    float gazeduration = 3;
    string[] ScenesTag = { "VRFarm", "VRBow", "VRBoat", "VRBrush" };

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, RayLength))
        {
            for (int i = 0; i < ScenesTag.Length; i++)
            {
                if (hit.collider.tag == ScenesTag[i])
                {
                    time += Time.deltaTime;
                    if (!TeleportMarker.activeSelf)
                    {
                        TeleportMarker.SetActive(true);
                        SceneIcons[i].GetComponent<Animation>().Play();
                    }
                    TeleportMarker.transform.position = hit.point;
                    ChangeScene(ScenesTag[i]);
                }
            }
        }
        else
        {
            TeleportMarker.SetActive(false);
            for (int i = 0; i < ScenesTag.Length; i++)
            {
                SceneIcons[i].GetComponent<Animation>().Stop();
            }
            time = 0f;
        }
    }


    void ChangeScene(string SceneTag)
    {
        if (TeleportMarker.activeSelf && time >= gazeduration)
        {
            SceneManager.LoadScene(SceneTag);
        }
    }

}
