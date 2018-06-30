using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject player;

    public float speed = 1f;
    public float checkFrequency = 1f;
    public GUIController GUI;

    public float timeToDie = 1f;
    private float timeDead = 0f;
    private bool dead = false;

   
    private float lastCheck = 0f;
    private Vector3 direction;

    private Rigidbody rb;
    private EnemyProperties enemy;
    private BossAttackPattern attackPattern;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        enemy = GetComponent<EnemyPropertyController>().properties;
        Debug.Log(GetComponent<Renderer>().material.GetFloat(Shader.PropertyToID("Vector1_30FACB43")));

        if (enemy.isBoss) {
            switch (enemy.bossAttackType) {
                case 0:
                    attackPattern = new AimAttack(gameObject, player);
                    break;
                default:
                    attackPattern = new NoAttack(gameObject, player);
                    break;
            }
        } else {
            attackPattern = new NoAttack(gameObject, player);
        }
            
    }

    // Update is called once per frame
    void Update () {

        if(dead) {

            timeDead += Time.deltaTime;

            GetComponent<Renderer>().material.SetFloat(Shader.PropertyToID("Vector1_30FACB43"), timeToDie - timeDead);

            if(timeToDie - timeDead <= 0) Destroy(this.gameObject);

            return;
        }

        lastCheck += Time.deltaTime;

        if(lastCheck >= checkFrequency) {
            lastCheck = 0;

            UpdateEnemyPath();
        }

        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        attackPattern.Update();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Player")) {
            rb.AddForce(-(player.transform.position - transform.position).normalized * 5, ForceMode.Impulse);
            player.GetComponent<PlayerControl>().AddDamage(enemy.attackDamage);
        }
    }

    void UpdateEnemyPath() {
        direction = (player.transform.position - transform.position).normalized;
    }

    public void OnDeath() {
        GUI.AddScore(1);
        dead = true;
        Debug.Log("Dead");
    }
}
