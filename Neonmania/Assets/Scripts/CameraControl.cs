using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public GameObject player;

    public Vector3 offset, zoomOffset;
    public float zoomFactor;
    public float maxZoom;

    public Rigidbody playerrb;
    

    // Use this for initialization
    void Start() {
        maxZoom = 10f;
        playerrb = player.GetComponent<Rigidbody>();
        offset = transform.position - player.transform.position;
        zoomOffset = offset.normalized * maxZoom;
    }

    // Update is called once per frame
    void LateUpdate() {
        zoomFactor = playerrb.velocity.magnitude / player.GetComponent<PlayerControl>().maxSpeed;
        transform.position = player.transform.position + offset + zoomOffset * zoomFactor;
    }
}
