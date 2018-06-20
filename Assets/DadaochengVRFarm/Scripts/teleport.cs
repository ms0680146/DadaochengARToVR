using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

    public GameObject TeleportMarker;
    public Transform Player;
    public float RayLength = 50f;
    float time;
    float gazeduration = 3;

	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, RayLength))
        {
            if (hit.collider.tag == "Ground")
            {
                time += Time.deltaTime;

                if (!TeleportMarker.activeSelf)
                {
                    TeleportMarker.SetActive(true);
                }
                TeleportMarker.transform.position = hit.point;
            }
            else
            {
                TeleportMarker.SetActive(false);
                time = 0f;
            }

            TelePort();
        }
       }

    void TelePort()
    {
        if (TeleportMarker.activeSelf && time >= gazeduration)
        {
            Vector3 markerPosition = TeleportMarker.transform.position;
            Player.position = new Vector3(markerPosition.x, Player.position.y, markerPosition.z);
        }
    }
        	
	}
