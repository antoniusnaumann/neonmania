using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyType", menuName = "Enemy Type")]
public class EnemyProperties : ScriptableObject {

	public float speed = 2f;
    public TColor color;
    public float damageLevel = 1f; // higher is weaker
    public float scale = 0.8f;
    public bool isBoss = false;
}
