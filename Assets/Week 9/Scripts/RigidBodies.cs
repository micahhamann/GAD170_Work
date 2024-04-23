using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodies : MonoBehaviour
{
    public Rigidbody myRigid;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //adding force
        {
            myRigid.AddForce(new Vector3(0, 1000, 0));
        }

        //myRigid.MovePosition(new Vector3(0, 20, 0));
    }


}
