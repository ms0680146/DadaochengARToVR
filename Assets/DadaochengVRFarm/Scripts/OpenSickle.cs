using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSickle : MonoBehaviour {

    public GameObject TeleportMarker;
    public GameObject Sickle;

    public float RayLength = 50f;
    float time;
    float gazeduration = 2;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, RayLength))
        {
            if (hit.collider.tag == "ToolIcon")
            {
                time += Time.deltaTime;
                if (!TeleportMarker.activeSelf)
                {
                    TeleportMarker.SetActive(true);
                }
                TeleportMarker.transform.position = hit.point;
                OpenSickleUI();
            }
        }
        else
        {
            TeleportMarker.SetActive(false);
            time = 0f;
        }
    }

    void OpenSickleUI()
    {
        if (TeleportMarker.activeSelf && time >= gazeduration)
        {
            Sickle.SetActive(true);
        }
    }
}
