using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColorChanger : MonoBehaviour {

    public EnemyProperties enemy;
    public IKillable killHandler;

    private CMYColor currentColor;


	private void Start () {
        currentColor = enemy.color;
	}
	
	private void Update () {
        GetComponent<Material>().color = currentColor.AsColor();
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("PlayerProjectile")) {
            // TODO Change when Jasper is ready
            // CMYColor hitColor = collision.collider.GetComponent<ProjectileController>().Color;
            // currentColor += enemy.weakness * hitColor;

            if (currentColor.IsBlack()) {
                killHandler.Kill();
            }
        }
    }
}
