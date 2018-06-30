using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
	private Rigidbody rb;
	public CMYColor color;
	public float velocity;
	public Vector3 direction;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.AddForce(direction.normalized * velocity, ForceMode.Impulse);
	}

	// Update is called once per frame
	void Update () {
	}
}
