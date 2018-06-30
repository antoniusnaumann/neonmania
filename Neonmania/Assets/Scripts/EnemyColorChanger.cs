using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColorChanger : MonoBehaviour {

    private EnemyProperties enemy;
    private EnemyPathfinding killHandler;
    private CMYColor currentColor;


	private void Start () {
        enemy = GetComponent<EnemyPropertyController>().properties;
        killHandler = GetComponent<EnemyPathfinding>();
        currentColor = enemy.color;

        ApplyColor(currentColor);
	}
	
	private void Update () {
        ApplyColor(currentColor);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("PlayerProjectile")) {
            CMYColor hitColor = collision.collider.GetComponent<ProjectileController>().color;
            currentColor += enemy.weakness * hitColor;

            if (currentColor.IsBlack()) {
                killHandler.OnDeath();
            }
        }
    }

    private void ApplyColor(CMYColor color) {
        // TODO
    }
}
