using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {

    private Vector3 rotation;

    public float rotationSpeed = 5f;

	// Use this for initialization
	void Start () {
        rotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        rotation.y += Time.deltaTime * rotationSpeed;

        transform.rotation = Quaternion.Euler(rotation);
	}
}
