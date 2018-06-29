using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Transform enemy;
    public Transform spawnPlane;

    public float timeBetweenWaves = 5f;
    public float startCountdown = 2f;
    public float timeBetweenEnemies = .5f;

    private int waveNumber = 0;

    // Use this for initialization
    void Start () {
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
        Vector3 scale = spawnPlane.localScale / 2;

        float x = Random.Range(pos.x - scale.x, pos.x + scale.x);
        float y = Random.Range(pos.y - scale.y, pos.y + scale.y);

        Vector3 spawnPoint = new Vector3(x, y, transform.localScale.z / 2);

        Instantiate(enemy, spawnPoint, new Quaternion());
    }
}
