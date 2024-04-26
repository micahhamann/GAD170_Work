using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerCutScenes : MonoBehaviour
{

    public Camera mainCamera;
    public PlayableDirector cutscene;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        mainCamera.targetDisplay = 1;

        cutscene.Play();

        cutscene.stopped += OnTimeLineFinished;
    }

    private void OnTimeLineFinished(PlayableDirector director)
    {
        mainCamera.targetDisplay = 0;
    }
}
