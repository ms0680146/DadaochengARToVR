using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushOpen : MonoBehaviour {

    public GameObject TeleportMarker;
    public GameObject Brush;

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
                TeleportMarker.transform.localRotation = Quaternion.Euler(new Vector3(90,0, 0));
                OpenPaddleUI();
            }
        }
        else
        {
            TeleportMarker.SetActive(false);
            time = 0f;
        }
    }

    void OpenPaddleUI()
    {
        if (TeleportMarker.activeSelf && time >= gazeduration)
        {
            Brush.SetActive(true);
        }
    }
}
