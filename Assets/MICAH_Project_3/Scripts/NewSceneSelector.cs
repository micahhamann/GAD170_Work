using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewSceneSelector : MonoBehaviour
{

    public int sceneSelector = 1;
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger active");

        if(other.CompareTag("Player"))
        {

            GameManager3.instance.NewScene(sceneSelector);
            
        }
        
    }

}
