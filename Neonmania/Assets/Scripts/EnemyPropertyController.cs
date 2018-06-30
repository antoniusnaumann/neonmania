using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPropertyController : MonoBehaviour {

    public EnemyProperties properties;

    private double lifetime;

    void Start() {
        lifetime = Time.time;
    }

    void Update() {
        //EnemyMaterial mat = GetComponent<Material>();
    }
}
