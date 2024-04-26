using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseHead : MonoBehaviour
{

    public Transform player;
    public float maxNeckExtension = 0.5f;
    private Vector3 initialNeckPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        initialNeckPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;

        // Clamp the length of the direction vector to maxNeckExtension
        float distanceToPlayer = Mathf.Min(directionToPlayer.magnitude, maxNeckExtension);

        // Calculate the target position of the neck
        Vector3 targetNeckPosition = initialNeckPosition + directionToPlayer.normalized * distanceToPlayer;

        // Update the position of the horse's neck
        transform.position = targetNeckPosition;

        // Rotate the horse to look at the player
        //Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);
        //transform.rotation = targetRotation;
    }
}
