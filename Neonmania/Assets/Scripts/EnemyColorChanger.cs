using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColorChanger : MonoBehaviour {

    public EnemyProperties enemy;

    private CMYColor currentColor;


	private void Start () {
		
	}
	
	private void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("PlayerProjectile")) {
            CMYColor hitColor = collision.collider.GetComponent<ProjectileController>().Color;

        }
    }
}
