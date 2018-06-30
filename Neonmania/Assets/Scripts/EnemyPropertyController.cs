using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPropertyController : MonoBehaviour {

    public EnemyProperties properties;

    private float lifetime;

    void Start() {
        lifetime = 0f;
    }

    void Update() {
        lifetime += Time.deltaTime;

        GetComponent<Renderer>().material.SetFloat(Shader.PropertyToID("Vector1_30FACB43"), lifetime);
    }
}
