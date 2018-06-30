using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform player;

    public float speed = 1f;
    public float checkFrequency = 1f;

    public float timeToDie = 1f;
    private float timeDead = 0f;
    private bool dead = false;

    private float lastCheck = 0f;
    private Vector3 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(dead) {

            timeDead += Time.deltaTime;

            GetComponent<Renderer>().material.SetFloat(Shader.PropertyToID("Vector1_30FACB43"), timeToDie - timeDead);

            return;
        }

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

    public void OnDeath() {
        dead = true;

        Debug.Log("Dead");
    }
}
