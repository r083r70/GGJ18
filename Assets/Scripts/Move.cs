using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {


    public Rigidbody rb;
    public float speedMovement = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();



    }

    private void Update()
    {

        float inputX = Input.GetAxis("Vertical");
        float inputZ = Input.GetAxis("Horizontal");


        float moveX = inputX * speedMovement * Time.deltaTime;
        float moveZ = inputZ * speedMovement * Time.deltaTime;

        rb.AddForce(moveX, 0, moveZ);
         


    }

    


}
