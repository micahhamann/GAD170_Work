using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLearn : MonoBehaviour
{
    public AudioClip clipToPlay;
    public AudioClip dogBark;
    public AudioSource sourceToPlay;

    // Start is called before the first frame update
    void Start()
    {
        sourceToPlay.clip = clipToPlay;
        sourceToPlay.Play();


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //play the dog sound
            sourceToPlay.PlayOneShot(dogBark);

            //Common audio way. Creates new audio stuff and does task and then deletes
            //Takes in clip and position in world to play the clip
            AudioSource.PlayClipAtPoint(dogBark, new Vector3(0, 0, 0));
        }
    }
}
