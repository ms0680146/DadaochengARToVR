using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLayerControl : MonoBehaviour {

    public GameObject TeleportMarker;
    public GameObject MapUI;
    public List<GameObject> MapLayers;
    public float RayLength = 100f;
    float time;
    float gazeduration = 2;
    string[] maplayersicon = { "SatelliteStreet", "Street", "Taiwan1932", "Taiwan1924", "Taiwan1897","CloseMapUI" }; 

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, RayLength))
        {
            for(int i = 0; i < maplayersicon.Length; i++)
            {
                if (hit.collider.tag == maplayersicon[i])
                {
                    time += Time.deltaTime;
                    if (!TeleportMarker.activeSelf)
                    {
                        TeleportMarker.SetActive(true);
                    }
                    TeleportMarker.transform.position = hit.point;
                    TeleportMarker.transform.localScale = new Vector3(3f, 0, 3f);
                    TeleportMarker.transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));
                    OpenMapLayer(maplayersicon[i]);
                }
            }
        }
        else
        {
            TeleportMarker.SetActive(false);
            time = 0f;
        }
    }

    void OpenMapLayer(string layername)
    {
        if (TeleportMarker.activeSelf && time >= gazeduration)
        {
            if(layername == "SatelliteStreet")
            {
                MapLayers[0].SetActive(true);
                MapLayers[1].SetActive(false);
            }
            if (layername == "Street")
            {
                MapLayers[1].SetActive(true);
                MapLayers[0].SetActive(false);
            }
            if (layername == "Taiwan1897")
            {
                MapLayers[2].SetActive(true);
                MapLayers[3].SetActive(false);
                MapLayers[4].SetActive(false);
            }
            if (layername == "Taiwan1924")
            {
                MapLayers[3].SetActive(true);
                MapLayers[4].SetActive(false);
                MapLayers[2].SetActive(false);
            }
            if (layername == "Taiwan1932")
            {
                MapLayers[4].SetActive(true);
                MapLayers[3].SetActive(false);
                MapLayers[2].SetActive(false);
            }

            if (layername == "CloseMapUI")
            {
                MapUI.SetActive(false);
            }

        }
    }
}
