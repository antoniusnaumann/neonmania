using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAttack : BossAttackPattern {

    private readonly float timeBetweenShoot = 1;
    private readonly int projectilesInWave = 20;
    private readonly float timeBetweenWaves = 5;
    private readonly float projectileVelocity = 10f;
    private readonly CMYColor[] attackColors = {
        CMYColor.CYAN,
        CMYColor.MAGENTA,
        CMYColor.YELLOW
    };

    private int projectileCount = 0;
    private int color = 0;


    public override void Start() {
        StartCoroutine("Shoot");
    }

    private IEnumerator Shoot() {
        for (;;) {
            CreateParticle();
            projectileCount++;

            if (projectileCount > projectilesInWave) {
                projectileCount = 0;
                color = (color + 1) % 3;
                yield return new WaitForSeconds(timeBetweenWaves);
            } else {
                yield return new WaitForSeconds(timeBetweenShoot);
            }
        }
    }

    private void CreateParticle() {
        Vector3 projectilePosition = new Vector3(boss.transform.position.x, player.transform.position.y,
            boss.transform.position.z);
        Vector3 move = (projectilePosition - player.transform.position).normalized;
        GameObject projectile = Instantiate(projectilePrefab, projectilePosition, boss.transform.rotation);
        ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
        projectileController.color = attackColors[color];
        projectileController.direction = move;
        projectileController.velocity = projectileVelocity;
        // TODO destroy
    }
}
