using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewSceneSelector : MonoBehaviour
{

    public int sceneSelector = 1; //this variable tells us which scene to load
    

    //When player triggers box collider, send to new scene
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger active");

        if(other.CompareTag("Player"))
        {

            GameManager3.instance.NewScene(sceneSelector);
            
        }
        
    }

}
