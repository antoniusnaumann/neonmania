using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Transform enemy;
    public Transform spawnPlane;
    public Transform player;

    public float timeBetweenWaves = 5f;
    public float startCountdown = 2f;
    public float timeBetweenEnemies = .5f;
    public float minimumDistanceToPlayer = 2f;

    private int waveNumber = 0;

    private Bounds bounds;

    // Use this for initialization
    void Start () {
        Mesh planeMesh = spawnPlane.GetComponent<MeshFilter>().mesh;
        bounds = planeMesh.bounds;
    }

    // Update is called once per frame
    void Update() {
        if (startCountdown < 0f) {
            StartCoroutine(SpawnWave());
            startCountdown = timeBetweenWaves;
        }

        startCountdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave() {

        for (int i = 0; i <= waveNumber; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }

        waveNumber++;
    }

    private void SpawnEnemy() {

        Vector3 pos = spawnPlane.position;
        float scaleX = (spawnPlane.localScale.x * bounds.size.x) / 2;
        float scaleZ = (spawnPlane.localScale.z * bounds.size.z) / 2;

        Vector3 spawnPoint;

        do {
            float x = Random.Range(pos.x - scaleX, pos.x + scaleX);
            float z = Random.Range(pos.z - scaleZ, pos.z + scaleZ);

            spawnPoint = new Vector3(x, enemy.localScale.y / 2, z);
        } while ( (player.position - spawnPoint).magnitude < minimumDistanceToPlayer);


        Instantiate(enemy, spawnPoint, new Quaternion());
    }
}
