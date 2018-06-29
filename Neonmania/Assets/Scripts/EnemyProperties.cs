using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyType", menuName = "Enemy Type")]
public class EnemyProperties : ScriptableObject {

    [Header("Movement Properties")]
	public float speed = 2f;

    [Header("Init Values")]
    public CMYColor color;

    [Header("Strength")] 
    [Range(0f, 1f)]
    public float weakness = 1f;             // higher is weaker
    [Range(0.3f, 5f)]
    public float scale = 0.8f;              // higher is greater
    [Range(0f, 1f)]
    public float strengthIndicator = 0.1f;    // higher is stronger 

    [Header("Boss Properties")]
    public bool isBoss = false;             // if true, players
}
