using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchChangeScene : MonoBehaviour {

    string[] scenenames = {"DadaochengVRTransition", "DadaochengVRMap","VRFarm", "VRBow", "VRBoat", "VRBrush" };

    private void OnTriggerEnter(Collider col)
    {
        for (int i = 0; i < scenenames.Length; i++)
        {
            if (col.gameObject.tag == scenenames[i])
            {
                ChangeScene(scenenames[i]);
            }
        }

    }

    void ChangeScene(string layername)
    {
        SceneManager.LoadScene(layername);
    } 
    
}
