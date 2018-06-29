using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private Rigidbody rb;


    public float acceleration = 1f;
    public float maxSpeed = 10f;
    public float deceleration = 2f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Before performing physics calculation
    void FixedUpdate() {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 v3 = new Vector3(moveHorizontal * acceleration, 0f, moveVertical * acceleration);


        if (moveHorizontal==0 && moveVertical==0)
        {
            //The player is not pressing any buttons, adding the mirrored vector to slow down
            Vector3 mirrorDirection = rb.velocity * (-1);
            rb.AddForce(mirrorDirection.normalized * deceleration);
            
        }
        else
        {
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
            else
            {
                rb.AddForce(v3);
            }
        }


        
        
        

    }

    // Update is called once per frame
    void Update () {
		
	}
}
