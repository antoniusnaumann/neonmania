using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour {

    public Transform player;

    public float speed = 1f;
    public float checkFrequency = 1f;

    private float lastCheck = 0f;
    private Vector3 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lastCheck += Time.deltaTime;

        if(lastCheck >= checkFrequency) {
            lastCheck = 0;

            UpdateEnemyPath();
        }

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void UpdateEnemyPath() {
        direction = (player.position - transform.position).normalized;
    }
}
