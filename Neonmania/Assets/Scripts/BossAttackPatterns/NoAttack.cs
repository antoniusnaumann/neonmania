using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAttack : BossAttackPattern {

    public NoAttack(GameObject boss, GameObject player) : base(boss, player) {}

    public override void Start() {}

    public override void Update() {}
}
