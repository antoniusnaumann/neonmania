using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossAttackPattern : MonoBehaviour {

    public GameObject boss;
    public GameObject player;
    public GameObject projectilePrefab;


    public abstract void Start();
}
