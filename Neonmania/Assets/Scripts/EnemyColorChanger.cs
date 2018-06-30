using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColorChanger : MonoBehaviour {

    private readonly CMYColor[] level1Colors = {
        CMYColor.CYAN,
        CMYColor.MAGENTA,
        CMYColor.YELLOW
    };

    private readonly CMYColor[] level2Colors = {
        CMYColor.RED,
        CMYColor.GREEN,
        CMYColor.BLUE
    };

    private EnemyProperties enemy;
    private EnemyPathfinding killHandler;
    private CMYColor currentColor;


	private void Start () {
        enemy = GetComponent<EnemyPropertyController>().properties;
        killHandler = GetComponent<EnemyPathfinding>();
        int level = GetComponent<EnemyPropertyController>().properties.level;

        currentColor = GetLevelColor(level);
        ApplyColor(currentColor);
	}
	
	private void Update () {

        ApplyColor(currentColor);
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("PlayerProjectile")) {
            CMYColor hitColor = collider.GetComponent<ProjectileController>().color;
            currentColor += enemy.weakness * hitColor;

            Debug.Log("Hit: " + currentColor.ToString());

            if (currentColor.IsBlack()) {
                killHandler.OnDeath();
            }
        }
    }

    private CMYColor GetLevelColor(int level) {
        int colorValue = UnityEngine.Random.Range(0, 3);
        switch (level) {
            case 0:
                return level1Colors[colorValue];
            case 1:
                return level2Colors[colorValue];
            case 2:
                return CMYColor.WHITE;
            default:
                throw new ArgumentException(
                    string.Format("Level over {0} not implemented yet", level));
        }
    }

    private void ApplyColor(CMYColor color) {
        GetComponent<Renderer>().material.SetColor(Shader.PropertyToID("Color_53254DB6"), color.AsHDRColor(5f));
    }
}
