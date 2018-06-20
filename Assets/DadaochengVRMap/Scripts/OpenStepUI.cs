using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStepUI : MonoBehaviour {

    public GameObject TeleportMarker;
    public GameObject StepUI;
    public float RayLength = 50f;
    float time;
    float gazeduration = 2;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, RayLength))
        {
            if (hit.collider.tag == "StepIcon")
            {
                time += Time.deltaTime;
                if (!TeleportMarker.activeSelf)
                {
                    TeleportMarker.SetActive(true);
                }
                TeleportMarker.transform.position = hit.point;
                TeleportMarker.transform.localScale = new Vector3(0.2f, 0, 0.2f);

                OpenStep();
            }
            if (hit.collider.tag == "CloseStepIcon")
            {
                time += Time.deltaTime;
                if (!TeleportMarker.activeSelf)
                {
                    TeleportMarker.SetActive(true);
                }
                TeleportMarker.transform.position = hit.point;
                TeleportMarker.transform.localScale = new Vector3(3f, 0, 3f);
                TeleportMarker.transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));

                CloseStep();
            }
        }
        else
        {
            TeleportMarker.SetActive(false);
            time = 0f;
        }
    }

    void OpenStep()
    {
        if (TeleportMarker.activeSelf && time >= gazeduration)
        {
            StepUI.SetActive(true);
        }
    }

    void CloseStep()
    {
        if (TeleportMarker.activeSelf && time >= gazeduration)
        {
            StepUI.SetActive(false);
        }
    }
}
