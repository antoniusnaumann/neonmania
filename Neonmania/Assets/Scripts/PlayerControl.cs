using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private Rigidbody rb;

    public float speed = 1f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Before performing physics calculation
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 v3 = new Vector3(moveHorizontal * speed, 0f, moveVertical * speed);

        rb.AddForce(v3);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
