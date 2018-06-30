using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	private Rigidbody rb;

	public CMYColor color;
	public float velocity;
	public Vector3 direction;

    /*public GameObject doNotAssignManually;
    private bool stoppedFlying = false;*/

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.AddForce(direction.normalized * velocity, ForceMode.Impulse);
        ApplyColor(color);
	}

	// Update is called once per frame
	void Update () {
       /* if(doNotAssignManually != null) {

            if (!stoppedFlying) {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                stoppedFlying = true;
            }

            Vector3 vector = doNotAssignManually.transform.position - this.transform.position;

            vector.Normalize();

            transform.position = vector * velocity * Time.deltaTime;
        }*/
	}

    private void ApplyColor(CMYColor color) {
        GetComponent<Renderer>().material.SetColor(Shader.PropertyToID("Color_D1E4B0CA"), color.AsColor());
    }
}
