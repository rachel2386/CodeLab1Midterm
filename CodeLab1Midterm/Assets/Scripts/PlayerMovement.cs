using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody myRB;
    private Camera myCam;
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myCam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        myRB.velocity = Vector3.right * Input.GetAxis("Horizontal") 
                        + Vector3.up *- Input.GetAxis("Vertical");
        
        //myCam.transform.LookAt(transform);
    }

    
   
}
