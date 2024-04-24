using UnityEngine;

public class SpeechBubbleController : MonoBehaviour
{
    void Update()
    {
        // Face the main camera (assuming the main camera is tagged as "MainCamera")
        Transform mainCameraTransform = Camera.main.transform;
        transform.LookAt(transform.position + mainCameraTransform.forward, mainCameraTransform.up);
        
    }
}

