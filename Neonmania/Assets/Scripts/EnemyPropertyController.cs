using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPropertyController : MonoBehaviour {

    public EnemyProperties properties;

    private float lifetime;

    void Start() {
        lifetime = Time.time;
    }

    void Update() {
        GetComponent<Renderer>().material.SetFloat("Time", Time.time - lifetime);
    }
}
