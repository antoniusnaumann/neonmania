using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour {

    private Rigidbody rb;

    public CMYColor color;
    public float velocity;
    public Vector3 direction;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction.normalized * velocity, ForceMode.Impulse);
        ApplyColor(color);
    }
    

    private void ApplyColor(CMYColor color) {
        GetComponent<Renderer>().material.SetColor(Shader.PropertyToID("Color_D1E4B0CA"), color.AsColor());
    }
}
