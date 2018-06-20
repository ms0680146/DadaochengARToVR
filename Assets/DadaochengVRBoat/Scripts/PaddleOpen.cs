using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleOpen : MonoBehaviour {

    public GameObject TeleportMarker;
    public GameObject Paddle;

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
                TeleportMarker.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));

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
            Paddle.SetActive(true);
        }
    }
}
